using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Gui : MonoBehaviour
{

    public Button btnRecommencer;
    /// Représente la coordonnée en x de départ du bouton recommencer
    private float xDepart;
    /// Représente la coordonnée en y de départ du bouton recommencer 
    private float yDepart;
    /// Référence vers le sccript de collision de notre personnage.  Va nous permettre de réinitialiser les vies du personnage.
    private Collisions perso;
    /// Champs texte pour inscrire les points de vies du personnage.  Publique pour que le lien soit possible dans l'éditeur de Unity avec un drag and drop 
    public Text txtVies;
    /// Champs texte qui indique que la partie est terminée.  Au départ, il est invisible et devient visible lorsque le personnage n'a plus de points de vies
    public Text txtGameOver;
    public static Gui instance;

    /// Sera exécuté au démarrage de l'application lorsque la caméra sera initialisée
    void Start()
    {
        //gestion de l'ajout d'un écouteur sur le bouton pour détecter l'événement click.
        Button btn = btnRecommencer.GetComponent<Button>();
        btn.onClick.AddListener(btnClick);

        //on conserve les positions de départ du bouton pour le repositionner lors de la fin de la partie
        xDepart = btnRecommencer.transform.position.x;
        yDepart = btnRecommencer.transform.position.y;

        //on déplace le bouton en dehors des limites de l'écran pour qu'il ne soit pas visible
        btnRecommencer.transform.position = new Vector3(1200, 2000, 0);

        instance = this; //gestion de notre référence statique sur notre script

        txtVies.text = "Vie : 3";
        txtGameOver.enabled = false;
    }

    /// Cette méthode sera appelée par notre script collisions.  Elle va permettre au personnage d'indiquer à l'interface utilisateur qu'il vient de perdre un points de vies
    /// <param name="vie">Le texte que l'on doit afficher dans le champs texte</param>
    public void updateVies(string vie)
    {
        txtVies.text = vie;
    }


    /// Cette méthode sera appelée par notre script collisions.  Elle va permettre au personnage d'indiquer à l'interface utilisateur que la partie est terminée.
    /// <param name="appelant">Référence vers le script de collision.</param>
    public void finPartie(Collisions appelant)
    {
        txtGameOver.enabled = true;
        this.perso = appelant;
        Time.timeScale = 0f; //faire une pause du jeu.
                             //on déplace le bouton recommencer pour le rendre visible
        btnRecommencer.transform.position = new Vector3(xDepart, yDepart, 0);
    }
    
    /// Méthode qui sera déclenchée lors d'un click sur le bouton redémarrer
    private void btnClick()
    {
        perso.redemarrer(); //pour réinitialiser les points de vies du personnage
        SceneManager.LoadScene(0); //on recharge la scène
        Time.timeScale = 1; //on repart le jeu (annulation de la pause)
        txtGameOver.enabled = false;
    }
}
