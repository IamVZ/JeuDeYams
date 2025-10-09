using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

/*
    Structure Joueur
        Idée: Représente les informations d'un joueur, incluant son identifiant, son pseudo, ses challenges restants et la somme des challenges mineurs.
        Entrée: 
            - int ID: Identifiant unique du joueur.
            - string Pseudo: Nom du joueur.
            - List<string> ChallengeRestant: Liste des challenges restants pour le joueur.
            - int Sommemineur: Somme des points des challenges mineurs réalisés par le joueur.
        Sortie: Aucun
*/
public struct Joueur
{
  public int id; // Identifiant du joueur.
  public string pseudo; // Pseudo du joueur.
  public List<string> challengeRestant; // Liste des challenges restants pour le joueur.
  public int sommemineur; // Somme des points des challenges mineurs réalisés par le joueur.

  // Constructeur de la structure Joueur
  public Joueur(int ID, string Pseudo, List<string> ChallengeRestant, int Sommemineur)
  {
    id = ID; // Initialisation de l'identifiant du joueur.
    pseudo = Pseudo; // Initialisation du pseudo du joueur.
    challengeRestant = ChallengeRestant; // Initialisation de la liste des challenges restants.
    sommemineur = Sommemineur; // Initialisation de la somme des challenges mineurs.
  }
}

/*
    Structure result
        Idée: Représente les résultats d'un joueur pour un round, incluant les dés obtenus, le challenge choisi et le score.
        Entrée: 
            - int ID_player: Identifiant du joueur.
            - int[] DE: Tableau des valeurs des dés obtenus par le joueur.
            - string Chall: Challenge choisi par le joueur.
            - int Score: Score obtenu par le joueur pour ce round.
        Sortie: Aucun
*/
public struct result
{
  public int id_player; // Identifiant du joueur.
  public int[] de; // Tableau des valeurs des dés obtenus par le joueur.
  public string challenge; // Challenge choisi par le joueur.
  public int score; // Score obtenu par le joueur.

  // Constructeur de la structure result
  public result(int ID_player, int[] DE, string Chall, int Score)
  {
    id_player = ID_player; // Initialisation de l'identifiant du joueur.
    de = DE; // Initialisation des dés obtenus par le joueur.
    challenge = Chall; // Initialisation du challenge choisi par le joueur.
    score = Score; // Initialisation du score obtenu par le joueur.
  }
}

/*
    Structure Round
        Idée: Représente un round du jeu, incluant l'identifiant du round et les résultats des joueurs pour ce round.
        Entrée: 
            - int ID: Identifiant du round.
            - result[] Res: Tableau des résultats de chaque joueur pour le round.
        Sortie: Aucun
*/
public struct Round
{
  public int id; // Identifiant du round.
  public result[] res; // Tableau des résultats des joueurs pour ce round.

  // Constructeur de la structure Round
  public Round(int ID, result[] Res)
  {
    id = ID; // Initialisation de l'identifiant du round.
    res = Res; // Initialisation des résultats des joueurs pour ce round.
  }
}

/*
    Structure ScoreFinal
        Idée: Représente le score final d'un joueur, incluant son identifiant, son bonus et son score total.
        Entrée: 
            - int ID: Identifiant du joueur.
            - int Bonus: Bonus du joueur (si applicable).
            - int Score: Score final du joueur.
        Sortie: Aucun
*/
public struct ScoreFinal
{
  public int id; // Identifiant du joueur.
  public int bonus; // Bonus du joueur (si applicable).
  public int score; // Score final du joueur.

  // Constructeur de la structure ScoreFinal
  public ScoreFinal(int ID, int Bonus, int Score)
  {
    id = ID; // Initialisation de l'identifiant du joueur.
    bonus = Bonus; // Initialisation du bonus du joueur.
    score = Score; // Initialisation du score final du joueur.
  }
}



class Yams
{
  /*
  Fonction a faire:
    Fonctionnement de la partie:
    x -InitialisationJoueur
    x -InitialisationRound
    x -LancerDes
    x -RelanceDes
    x -choixChall
    x -CreerJSON

    Affichage:
    x -AffichageDebutTour
    x -AffichageFinTour
    x -AfficherDe
    x -AfficherTabRound

    Challenge:
    x -nombre de X
    x -Brelan
    X -Carre
    X -Full
    X -Petite suite
    x -Grande suite
    x -Yams
    x -Chance
  */


    /*
    Fonction NombreDeX
    Idée: Cette fonction calcule la somme des dés ayant une valeur égale à X en parcourant chaque élément d'un tableau.
    Entrée: 
    - int[] de : tableau d'entiers représentant les valeurs des dés.
    - int X : entier représentant la valeur cible à rechercher.
    Local: 
    - int somme : entier utilisé pour accumuler la somme des dés ayant la valeur X.
    Sortie: 
    - int somme : entier représentant la somme des dés ayant une valeur égale à X.
    Fonction NombreDeX(int[] de, int X):int
  */
  static int NombreDeX(int[] de, int X)
  {
    // Initialise la somme des dés ayant la valeur égale à X.
    int somme = 0;

    // Parcourt chaque valeur du tableau de dés.
    foreach (int val in de)
    {
      // Vérifie si la valeur du dé est égale à X.
      if (val == X)
      {
        // Ajoute la valeur du dé à la somme si elle correspond.
        somme += val;
      }
    }

    // Retourne la somme totale des dés ayant la valeur égale à X.
    return somme;
  }

  
  /*
    Fonction LancerDes
    Idée: Cette fonction attribue des valeurs aléatoires comprises entre 1 et 6 à chaque élément d'un tableau représentant des dés.
    Entrée: 
    - int[] dice : tableau d'entiers représentant les dés à lancer.
    Local: 
    - int i : entier utilisé pour parcourir les indices du tableau.
    - Random de : générateur de nombres aléatoires.
    Sortie: 
    - int[] dice : tableau d'entiers mis à jour avec les nouvelles valeurs des dés.
    Fonction LancerDes(int[] dice):int[]
  */
  static int[] LancerDes(int[] dice)
  {
    int i;
    Random de = new Random(); // Initialisation d'un générateur de nombres aléatoires.
    for (i = 0; i <= 4; i++) // Boucle pour parcourir tous les dés.
    {
        dice[i] = de.Next(1, 7); // Génère une valeur aléatoire entre 1 et 6 pour chaque dé.
    }

    return dice;
  }


  /*
    Fonction RelanceDes
    Idée: Cette fonction permet de relancer certains dés spécifiés par l'utilisateur, en leur attribuant une nouvelle valeur aléatoire entre 1 et 6.
    Entrée: 
    - int[] dice : tableau d'entiers représentant les valeurs des dés à modifier.
    - string relancer : chaîne de caractères contenant les indices des dés à relancer, séparés par des virgules.
    Local: 
    - string[] relance : tableau de chaînes de caractères résultant du découpage de la chaîne `relancer` à partir des virgules.
    - List<int> relan : liste d'entiers qui contient les indices des dés à relancer, convertis de la chaîne.
    - int i : entier utilisé pour parcourir les indices du tableau `relance`.
    - Random de : générateur de nombres aléatoires pour assigner de nouvelles valeurs aux dés.
    Sortie: 
    - int[] dice : tableau d'entiers mis à jour avec les nouvelles valeurs des dés.
  Fonction RelanceDes(int[] dice, string relancer):int[]
  */
  static int[] RelanceDes(int[] dice, string relancer)
  {
    string[] relance; // tableau contenant les indices des dés à relancer sous forme de chaînes
    List<int> relan = new List<int>(); // liste pour stocker les indices des dés à relancer sous forme d'entiers
    int i = 0; // variable utilisée pour parcourir le tableau relance
    relance = relancer.Split(','); // sépare la chaîne `relancer` sur les virgules pour obtenir les indices des dés à relancer
    foreach (string nb in relance)
    {
      relan.Add(int.Parse(relance[i])); // convertit chaque indice en entier et l'ajoute à la liste relan
      i = i + 1; // incrémente l'indice pour parcourir le tableau `relance`
    }
    
    Random de = new Random(); // crée un générateur de nombres aléatoires
    foreach (int val in relan)
    {
      dice[val - 1] = de.Next(1, 7); // relance le dé à l'indice `val-1` et lui assigne une nouvelle valeur entre 1 et 6
    }

    return dice; // retourne le tableau de dés mis à jour
  }

  /*
    Fonction chance
    Idée: Cette fonction calcule la somme totale des valeurs des cinq dés. Elle additionne toutes les valeurs des dés pour obtenir le score total.
    Entrée: 
    - int[] dice : tableau d'entiers représentant les valeurs des cinq dés.
    Local: 
    - int res : entier utilisé pour accumuler la somme des valeurs des dés.
    - int i : entier utilisé pour parcourir les indices du tableau `dice`.
    Sortie: 
    - int res : entier représentant la somme totale des valeurs des dés.
  Fonction chance(int[] dice):int
  */
  static int chance(int[] dice)
  {
    int res = 0; // initialisation de la variable pour stocker la somme des valeurs des dés
    int i; // variable utilisée pour parcourir le tableau des dés

    for (i = 0; i <= 4; i++) // boucle qui parcourt chaque dé (de 0 à 4 pour un total de 5 dés)
    {
      res = res + dice[i]; // ajoute la valeur du dé à la somme totale
    }
    return res; // retourne la somme totale des valeurs des dés
  }


  /*
    Fonction yams
    Idée: Cette fonction vérifie si tous les dés ont la même valeur. Si c'est le cas, le joueur obtient un score de 50 (Yam's), sinon le score est 0.
    Entrée: 
    - int[] dice : tableau d'entiers représentant les valeurs des cinq dés.
    Local: 
    - bool yams : booléen utilisé pour vérifier si tous les dés ont la même valeur.
    - int res : entier utilisé pour stocker le score, soit 50 si tous les dés sont identiques, sinon 0.
    - int i : entier utilisé pour parcourir les indices du tableau `dice`.
    Sortie: 
    - int res : entier représentant le score obtenu, soit 50 si tous les dés ont la même valeur, sinon 0.
  Fonction yams(int[] dice):int
  */
  static int yams(int[] dice)
  {
    bool yams = true; // suppose que tous les dés sont égaux
    int res = 0; // initialisation du score à 0
    int i; // variable utilisée pour parcourir le tableau des dés

    for (i = 0; i <= 4; i++) // boucle qui parcourt chaque dé
    {
      if (dice[i] != dice[0]) // si un dé est différent du premier, ce n'est pas un Yam's
      {
        yams = false; // indique que ce n'est pas un Yam's
      }
    }

    if (yams == false) // si yams est faux, le score reste 0
    {
      res = 0; // score de 0 si les dés ne sont pas tous identiques
    }
    else // si tous les dés ont la même valeur, le score est 50
    {
      res = 50; // score de 50 pour un Yam's
    }

    return res; // retourne le score final
  }


  /*
    Fonction brelan
    Idée: Cette fonction calcule le score d'un brelan (trois dés ayant la même valeur). Si un brelan est trouvé, le score est égal à la valeur du dé multipliée par 3.
    Entrée: 
    - int[] dice : tableau d'entiers représentant les valeurs des cinq dés.
    Local: 
    - int res : entier utilisé pour stocker le score final du brelan.
    - int cmpt : compteur utilisé pour compter le nombre de fois qu'une valeur est retrouvée parmi les dés.
    - int i : entier utilisé pour parcourir les indices du tableau `dice`.
    - int o : entier utilisé pour vérifier chaque valeur dans le tableau `dice`.
    - int val : entier représentant la valeur actuelle d'un dé à vérifier.
    Sortie: 
    - int res : entier représentant le score du brelan, ou 0 si aucun brelan n'est trouvé.
  Fonction brelan(int[] dice):int
  */
  static int brelan(int[] dice)
  {
    int res = 0; // initialisation du score à 0
    int cmpt = 0; // compteur d'occurrences de chaque valeur
    int i = 0; // variable pour parcourir les dés
    int o = 0; // variable pour vérifier chaque dé
    int val = 0; // variable pour stocker la valeur courante d'un dé

    while (cmpt < 3 && i <= 4) // tant qu'il y a moins de 3 occurrences et qu'on n'a pas vérifié tous les dés
    {
      val = dice[i]; // on prend la valeur du dé à la position i
      for (o = 0; o <= 4; o++) // boucle pour vérifier chaque dé
      {
        if (dice[o] == val) // si la valeur du dé est égale à celle du dé vérifié
        {
          cmpt = cmpt + 1; // incrémenter le compteur
        }
      }
      if (cmpt >= 3) // si on a trouvé 3 occurrences de la même valeur
      {
        res = val * 3; // le score est la valeur du dé multipliée par 3
      }
      cmpt = 0; // réinitialiser le compteur pour la prochaine vérification
      i = i + 1; // passer au dé suivant
    }

    return res; // retourner le score du brelan, ou 0 s'il n'y en a pas
  }


  /*
    Fonction carre
    Idée: Cette fonction calcule le score d'un carré (quatre dés ayant la même valeur). Si un carré est trouvé, le score est égal à la valeur du dé multipliée par 4.
    Entrée: 
    - int[] dice : tableau d'entiers représentant les valeurs des cinq dés.
    Local: 
    - int res : entier utilisé pour stocker le score final du carré.
    - int cmpt : compteur utilisé pour compter le nombre de fois qu'une valeur est retrouvée parmi les dés.
    - int i : entier utilisé pour parcourir les indices du tableau `dice`.
    - int o : entier utilisé pour vérifier chaque valeur dans le tableau `dice`.
    - int val : entier représentant la valeur actuelle d'un dé à vérifier.
    Sortie: 
    - int res : entier représentant le score du carré, ou 0 si aucun carré n'est trouvé.
  Fonction carre(int[] dice):int
  */
  static int carre(int[] dice)
  {
    int res = 0; // initialisation du score à 0
    int cmpt = 0; // compteur d'occurrences de chaque valeur
    int i = 0; // variable pour parcourir les dés
    int o = 0; // variable pour vérifier chaque dé
    int val = 0; // variable pour stocker la valeur courante d'un dé

    while (cmpt < 4 && i <= 4) // tant qu'il y a moins de 4 occurrences et qu'on n'a pas vérifié tous les dés
    {
      val = dice[i]; // on prend la valeur du dé à la position i
      for (o = 0; o <= 4; o++) // boucle pour vérifier chaque dé
      {
        if (dice[o] == val) // si la valeur du dé est égale à celle du dé vérifié
        {
          cmpt = cmpt + 1; // incrémenter le compteur
        }
      }
      if (cmpt >= 4) // si on a trouvé 4 occurrences de la même valeur
      {
        res = val * 4; // le score est la valeur du dé multipliée par 4
      }
      cmpt = 0; // réinitialiser le compteur pour la prochaine vérification
      i = i + 1; // passer au dé suivant
    }

    return res; // retourner le score du carré, ou 0 s'il n'y en a pas
  }


  /*
    Fonction full
    Idée: Cette fonction calcule le score d'un full (un brelan et une paire). Si un full est trouvé, le score est 25.
    Entrée: 
    - int[] dice : tableau d'entiers représentant les valeurs des cinq dés.
    Local: 
    - int res : entier utilisé pour stocker le score du full.
    - int cmpt : compteur utilisé pour compter les occurrences de chaque valeur.
    - int i : entier utilisé pour parcourir les indices du tableau `dice`.
    - int o : entier utilisé pour vérifier chaque valeur dans le tableau `dice`.
    - int val : entier représentant la valeur actuelle d'un dé à vérifier.
    - bool v1 : variable booléenne indiquant si un brelan a été trouvé.
    - bool v2 : variable booléenne indiquant si une paire a été trouvée.
    Sortie: 
    - int res : entier représentant le score du full, ou 0 si aucun full n'est trouvé.
  Fonction full(int[] dice):int
  */
  static int full(int[] dice)
  {
    int res = 0; // initialisation du score à 0
    int cmpt = 0; // compteur d'occurrences de chaque valeur
    int i = 0; // variable pour parcourir les dés
    int o = 0; // variable pour vérifier chaque dé
    int val = 0; // variable pour stocker la valeur courante d'un dé

    bool v1 = false; // booléen pour vérifier si un brelan a été trouvé
    bool v2 = false; // booléen pour vérifier si une paire a été trouvée

    // Vérification d'un brelan (3 dés ayant la même valeur)
    while (cmpt < 3 && i <= 4) // tant qu'il y a moins de 3 occurrences et qu'on n'a pas vérifié tous les dés
    {
      val = dice[i]; // on prend la valeur du dé à la position i
      for (o = 0; o <= 4; o++) // boucle pour vérifier chaque dé
      {
        if (dice[o] == val) // si la valeur du dé est égale à celle du dé vérifié
        {
          cmpt = cmpt + 1; // incrémenter le compteur
        }
      }
      if (cmpt == 3) // si on a trouvé 3 occurrences de la même valeur
      {
        v1 = true; // on marque que le brelan a été trouvé
      }
      cmpt = 0; // réinitialiser le compteur pour la prochaine vérification
      i = i + 1; // passer au dé suivant
    }

    i = 0; // réinitialiser i pour vérifier la paire

    // Vérification d'une paire (2 dés ayant la même valeur)
    while (cmpt < 2 && i <= 4) // tant qu'il y a moins de 2 occurrences et qu'on n'a pas vérifié tous les dés
    {
      val = dice[i]; // on prend la valeur du dé à la position i
      for (o = 0; o <= 4; o++) // boucle pour vérifier chaque dé
      {
        if (dice[o] == val) // si la valeur du dé est égale à celle du dé vérifié
        {
          cmpt = cmpt + 1; // incrémenter le compteur
        }
      }
      if (cmpt == 2) // si on a trouvé 2 occurrences de la même valeur
      {
        v2 = true; // on marque que la paire a été trouvée
      }
      cmpt = 0; // réinitialiser le compteur pour la prochaine vérification
      i = i + 1; // passer au dé suivant
    }

    if (v1 && v2) // si un brelan et une paire ont été trouvés
    {
      res = 25; // le score du full est 25
    }

    return res; // retourner le score du full, ou 0 s'il n'y en a pas
  }


  /*
    Fonction grande
    Idée: Cette fonction vérifie si les dés forment une suite de cinq chiffres consécutifs, et attribue un score de 40 si c'est le cas.
    Entrée: 
    - int[] dice : tableau d'entiers représentant les valeurs des cinq dés.
    Local: 
    - int res : entier utilisé pour stocker le score de la grande suite.
    - int o : entier représentant la valeur actuelle à vérifier dans la suite.
    - int i : variable pour parcourir les indices du tableau `dice`.
    - int t : compteur pour vérifier si le nombre de valeurs égales à `o` est 5.
    Sortie: 
    - int res : entier représentant le score de la grande suite, ou 0 si aucune suite n'est trouvée.
  Fonction grande(int[] dice):int
  */
  static int grande(int[] dice)
  {
    dice = diceTrie(dice); // trier le tableau de dés
    int o = 0; // variable représentant la valeur à vérifier dans la suite
    int i; // variable pour parcourir les indices du tableau
    int res = 0; // initialisation du score à 0
    int t; // compteur pour vérifier si le nombre de valeurs égales à o est 5

    // Vérification pour la suite commençant par 1
    o = 1; 
    t = 0; // réinitialiser le compteur
    for (i = 0; i <= 4; i++) // parcourir les dés
    {
      if (dice[i] == o) // si la valeur du dé est égale à o
      {
        o = o + 1; // passer à la valeur suivante dans la suite
        t = t + 1; // incrémenter le compteur
      }
    }
    if (t == 5) // si on a trouvé 5 dés consécutifs
    {
      res = 40; // attribuer un score de 40 pour la grande suite
    }

    // Vérification pour la suite commençant par 2
    o = 2; 
    t = 0; // réinitialiser le compteur
    for (i = 0; i <= 4; i++) // parcourir les dés
    {
      if (dice[i] == o) // si la valeur du dé est égale à o
      {
        o = o + 1; // passer à la valeur suivante dans la suite
        t = t + 1; // incrémenter le compteur
      }
    }
    if (t == 5) // si on a trouvé 5 dés consécutifs
    {
      res = 40; // attribuer un score de 40 pour la grande suite
    }

    return res; // retourner le score de la grande suite, ou 0 si aucune suite n'est trouvée
  }


  /*
    Fonction petite
    Idée: Cette fonction vérifie si les dés forment une suite de quatre chiffres consécutifs, et attribue un score de 30 si c'est le cas.
    Entrée: 
    - int[] dice : tableau d'entiers représentant les valeurs des cinq dés.
    Local: 
    - int res : entier utilisé pour stocker le score de la petite suite.
    - int o : entier représentant la valeur actuelle à vérifier dans la suite.
    - int i : variable pour parcourir les indices du tableau `dice`.
    - int t : compteur pour vérifier si le nombre de valeurs égales à `o` est 4.
    Sortie: 
    - int res : entier représentant le score de la petite suite, ou 0 si aucune suite n'est trouvée.
  Fonction petite(int[] dice):int
  */
  static int petite(int[] dice)
  {
    dice = diceTrie(dice); // trier le tableau de dés
    int o; // variable représentant la valeur à vérifier dans la suite
    int i; // variable pour parcourir les indices du tableau
    int res = 0; // initialisation du score à 0
    int t; // compteur pour vérifier si le nombre de valeurs égales à o est 4

    // Vérification pour la suite commençant par 1
    o = 1; 
    t = 0; // réinitialiser le compteur
    for (i = 0; i <= 4; i++) // parcourir les dés
    {
      if (dice[i] == o) // si la valeur du dé est égale à o
      {
        o = o + 1; // passer à la valeur suivante dans la suite
        t = t + 1; // incrémenter le compteur
      }
    }
    if (t == 4) // si on a trouvé 4 dés consécutifs
    {
      res = 30; // attribuer un score de 30 pour la petite suite
    }

    // Vérification pour la suite commençant par 2
    o = 2; 
    t = 0; // réinitialiser le compteur
    for (i = 0; i <= 4; i++) // parcourir les dés
    {
      if (dice[i] == o) // si la valeur du dé est égale à o
      {
        o = o + 1; // passer à la valeur suivante dans la suite
        t = t + 1; // incrémenter le compteur
      }
    }
    if (t == 4) // si on a trouvé 4 dés consécutifs
    {
      res = 30; // attribuer un score de 30 pour la petite suite
    }

    // Vérification pour la suite commençant par 3
    o = 3; 
    t = 0; // réinitialiser le compteur
    for (i = 0; i <= 4; i++) // parcourir les dés
    {
      if (dice[i] == o) // si la valeur du dé est égale à o
      {
        o = o + 1; // passer à la valeur suivante dans la suite
        t = t + 1; // incrémenter le compteur
      }
    }
    if (t == 4) // si on a trouvé 4 dés consécutifs
    {
      res = 30; // attribuer un score de 30 pour la petite suite
    }

    return res; // retourner le score de la petite suite, ou 0 si aucune suite n'est trouvée
  }

  /*
    Fonction diceTrie
    Idée: Cette fonction trie les valeurs des dés dans l'ordre croissant en utilisant l'algorithme de tri par échange.
    Entrée: 
    - int[] dice : tableau d'entiers représentant les valeurs des cinq dés à trier.
    Local: 
    - int tempo : variable temporaire pour échanger les valeurs des dés.
    - int i : variable pour parcourir les indices du tableau `dice`.
    - int o : variable pour comparer les valeurs du tableau `dice`.
    Sortie: 
    - int[] dice : tableau d'entiers trié dans l'ordre croissant.
  Fonction diceTrie(int[] dice):int[]
  */
  static int[] diceTrie(int[] dice)
  {
    int tempo; // variable temporaire pour l'échange des valeurs
    int i; // variable pour parcourir les indices du tableau
    int o; // variable pour comparer les éléments du tableau

    // Algorithme de tri par échange
    for (i = 0; i <= 4; i++) // parcourir les indices du tableau
    {
      for (o = 0; o <= 4; o++) // comparer chaque élément avec les autres
      {
        if (dice[o] > dice[i]) // si l'élément à l'indice o est supérieur à celui à l'indice i
        {
          tempo = dice[o]; // sauvegarder l'élément à l'indice o
          dice[o] = dice[i]; // échanger l'élément à l'indice o avec celui à l'indice i
          dice[i] = tempo; // assigner la valeur sauvegardée à l'indice i
        }
      }
    }

    return dice; // retourner le tableau trié
  }


  /*
      Procédure InitialisationJoueur
          Idée: Initialise les joueurs avec leurs noms, leurs challenges restants et leur score initial.
          Entrée: TabJoueur (Joueur[]) - Un tableau pour stocker les joueurs.
          Local: pseudo (string) - Le nom du joueur.
                  challengeRestant1 (List<string>) - Liste des challenges restants pour le premier joueur.
                  challengeRestant2 (List<string>) - Liste des challenges restants pour le deuxième joueur.
          Sortie: void - Aucune valeur retournée.
      Procédure InitialisationJoueur(TabJoueur)
  */
  static void InitialisationJoueur(Joueur[] TabJoueur)
  {
      // Déclaration des variables
      string pseudo;

      // Définition des challenges restants pour chaque joueur
      List<string> challengeRestant1 = new List<string> {
          "Nombre de 1", "Nombre de 2", "Nombre de 3", "Nombre de 4", "Nombre de 5", "Nombre de 6", 
          "Brelan", "Carré", "Full", "Petite Suite", "Grande Suite", "Yam's", "Chance"
      };
      List<string> challengeRestant2 = new List<string> {
          "Nombre de 1", "Nombre de 2", "Nombre de 3", "Nombre de 4", "Nombre de 5", "Nombre de 6", 
          "Brelan", "Carré", "Full", "Petite Suite", "Grande Suite", "Yam's", "Chance"
      };

      // Demande du nom du premier joueur et initialisation
      Console.WriteLine("Entrez le nom du Joueur 1 : ");
      pseudo = Console.ReadLine(); // Lecture du nom du joueur
      TabJoueur[0] = new Joueur(1, pseudo, challengeRestant1, 0); // Création du joueur 1 avec son nom et ses challenges

      // Demande du nom du deuxième joueur et initialisation
      Console.WriteLine("Entrez le nom du Joueur 2 : ");
      pseudo = Console.ReadLine(); // Lecture du nom du joueur
      TabJoueur[1] = new Joueur(2, pseudo, challengeRestant2, 0); // Création du joueur 2 avec son nom et ses challenges
  }


  /*
      Procédure InitialisationRound
          Idée: Initialise chaque round en créant des résultats distincts pour chaque joueur avec des tableaux de dés séparés.
          Entrée: TabRound (Round[]) - Un tableau pour stocker les rounds du jeu.
          Local: dice1 (int[]) - Tableau des dés pour le joueur 1.
                  dice2 (int[]) - Tableau des dés pour le joueur 2.
                  TabResult (result[]) - Tableau contenant les résultats des joueurs pour chaque round.
          Sortie: void - Aucune valeur retournée.
      Procédure InitialisationRound(TabRound)
  */
  static void InitialisationRound(Round[] TabRound)
  {
      // Initialisation de chaque round (de 1 à 13)
      for (int i = 0; i <= 12; i++)
      {
          // Création des tableaux de dés distincts pour chaque joueur
          int[] dice1 = new int[5]; // Dés du joueur 1
          int[] dice2 = new int[5]; // Dés du joueur 2

          // Création des résultats distincts pour chaque joueur
          result[] TabResult = new result[] 
          { 
              new result(1, dice1, "", 0),  // Résultat pour le joueur 1 avec un tableau de dés vide, challenge vide et score initial à 0
              new result(2, dice2, "", 0)   // Résultat pour le joueur 2 avec un tableau de dés vide, challenge vide et score initial à 0
          };

          // Initialisation du round avec ses propres résultats
          TabRound[i] = new Round(i + 1, TabResult); // Création du round avec son numéro (i+1) et ses résultats associés
      }
  }

  /*
      Procédure AffichageDebutTour
          Idée: Affiche les informations du joueur au début d'un tour (nom, challenges restants, somme mineur).
          Entrée: Tjoueur (Joueur[]) - Un tableau de joueurs contenant leurs informations.
                  Tround (Round[]) - Un tableau de rounds, mais non utilisé dans cette procédure.
                  numRound (int) - Le numéro du round actuel, mais non utilisé dans cette procédure.
                  numJoueur (int) - L'indice du joueur dont on souhaite afficher les informations.
          Local: challenge (string) - Variable utilisée pour parcourir les challenges restants du joueur.
          Sortie: void - Aucune valeur retournée.
      Procédure AffichageDebutTour(Tjoueur, Tround, numRound, numJoueur)
  */
  static void AffichageDebutTour(Joueur[] Tjoueur, Round[] Tround, int numRound, int numJoueur)
  {
    // Affiche le nom du joueur
    Console.WriteLine($"Joueur {numJoueur + 1} : {Tjoueur[numJoueur].pseudo} \n");

    // Affiche les challenges restants du joueur
    Console.Write("Challenges restants: ");
    foreach (string challenge in Tjoueur[numJoueur].challengeRestant)
    {
        Console.Write($"{challenge} | "); // Affiche chaque challenge avec un séparateur " | "
    }
    Console.WriteLine("\n"); // Saut de ligne après l'affichage des challenges restants

    // Affiche la somme des challenges mineurs du joueur
    Console.WriteLine($"Somme des challenges mineurs: {Tjoueur[numJoueur].sommemineur} \n");
  }


  /*
    Procédure afficheDe
        Idée: Affiche les dés obtenus par un joueur lors d'un round.
        Entrée: Tround (Round[]) - Un tableau de rounds contenant les résultats de chaque round.
                numRound (int) - Le numéro du round actuel.
                numJoueur (int) - L'indice du joueur dont on souhaite afficher les dés.
        Local: de (int) - Variable utilisée pour parcourir les dés du joueur.
        Sortie: void - Aucune valeur retournée.
    Procédure afficheDe(Tround, numRound, numJoueur)
  */
  static void afficheDe(Round[] Tround, int numRound, int numJoueur)
  {
      // Affiche les dés obtenus par le joueur
      Console.Write($"Dés obtenus : ");
      foreach (int de in Tround[numRound].res[numJoueur].de)
      {
          Console.Write($"{de} | "); // Affiche chaque dé avec un séparateur " | "
      }
      Console.WriteLine("\n"); // Saut de ligne après l'affichage des dés
  }

  
  /*
    Procédure afficheResult
        Idée: Affiche le score obtenu lors du round ainsi que le total des points du joueur.
        Entrée: Tround (Round[]) - Un tableau de rounds contenant les résultats de chaque round.
                TscoreFinal (ScoreFinal[]) - Un tableau contenant les scores finaux des joueurs.
                numRound (int) - Le numéro du round actuel.
                numJoueur (int) - L'indice du joueur dont on souhaite afficher les résultats.
        Local: Aucun.
        Sortie: void - Aucune valeur retournée.
    Procédure afficheResult(Tround, TscoreFinal, numRound, numJoueur)
  */
  static void afficheResult(Round[] Tround, ScoreFinal[] TscoreFinal, int numRound, int numJoueur)
  {
      // Affiche le score obtenu lors du round
      Console.WriteLine($"Score obtenu lors du round {numRound + 1} : {Tround[numRound].res[numJoueur].score}");
      
      // Affiche le total des points du joueur
      Console.WriteLine($"Total : {TscoreFinal[numJoueur].score}");
  }


  /*
      Procédure CreerJSON
          Idée: Crée un fichier JSON avec les informations des joueurs, des rounds et des scores finaux.
          Entrée: Tjoueur (Joueur[]) - Un tableau contenant les informations des joueurs.
                  Tround (Round[]) - Un tableau contenant les rounds et leurs résultats.
                  Tscore (ScoreFinal[]) - Un tableau contenant les scores finaux des joueurs.
          Local: sw (StreamWriter) - Utilisé pour écrire dans le fichier JSON.
          Sortie: void - Aucune valeur retournée.
      Procédure CreerJSON(Tjoueur, Tround, Tscore)
  */
  static void CreerJSON(Joueur[] Tjoueur, Round[] Tround, ScoreFinal[] Tscore)
  {
      // Crée un nouveau fichier JSON pour écrire les données
      StreamWriter sw = new StreamWriter("yams.json");

      // Section des paramètres
      sw.Write("{\"parameters\": {\"code\": \"groupe-test\",\"date\": \"");
      sw.Write(DateTime.Now.ToString("yyyy-MM-dd")); // Ajoute la date du jour au format YYYY-MM-DD
      sw.Write("\"},");

      // Section des joueurs
      sw.Write("\"players\": [");
      for (int i = 0; i < Tjoueur.Length; i++)
      {
          sw.Write("{\"id\": " + Tjoueur[i].id + ", \"pseudo\": \"" + Tjoueur[i].pseudo + "\"}");
          if (i < Tjoueur.Length - 1)
          {
              sw.Write(","); // Ajoute une virgule entre les joueurs sauf pour le dernier
          }
      }
      sw.Write("],");

      // Section des rounds
      sw.Write("\"rounds\": [");
      for (int i = 0; i < Tround.Length; i++)
      {
          sw.Write("{\"id\": " + Tround[i].id + ", \"results\": [");
          for (int j = 0; j < Tround[i].res.Length; j++)
          {
              sw.Write("{\"id_player\": " + Tround[i].res[j].id_player + ", \"dice\": [");

              // Concaténation des dés dans un tableau
              for (int k = 0; k < Tround[i].res[j].de.Length; k++)
              {
                  sw.Write(Tround[i].res[j].de[k]);
                  if (k < Tround[i].res[j].de.Length - 1)
                  {
                      sw.Write(","); // Ajoute une virgule entre les dés sauf pour le dernier
                  }
              }

              // Ajoute le challenge et le score du joueur
              sw.Write("], \"challenge\": \"" + Tround[i].res[j].challenge + "\", \"score\": " + Tround[i].res[j].score + "}");
              if (j < Tround[i].res.Length - 1)
              {
                  sw.Write(","); // Ajoute une virgule entre les résultats sauf pour le dernier
              }
          }
          sw.Write("]}");
          if (i < Tround.Length - 1)
          {
              sw.Write(","); // Ajoute une virgule entre les rounds sauf pour le dernier
          }
      }
      sw.Write("],");

      // Section des résultats finaux
      sw.Write("\"final_result\": [");
      for (int i = 0; i < Tscore.Length; i++)
      {
          sw.Write("{\"id_player\": " + Tscore[i].id + ", \"bonus\": " + Tscore[i].bonus + ", \"score\": " + Tscore[i].score + "}");
          if (i < Tscore.Length - 1)
          {
              sw.Write(","); // Ajoute une virgule entre les scores des joueurs sauf pour le dernier
          }
      }
      sw.Write("]}");

      // Ferme le StreamWriter pour sauvegarder le fichier
      sw.Close();
  }



    /*
    Fonction choixChall
    Idée: Cette fonction permet de sélectionner un challenge parmi plusieurs, en fonction du choix de l'utilisateur. 
    Elle vérifie si le challenge est encore disponible et met à jour le score du joueur, le challenge effectué et les bonus associés.
    Entrée: 
    - int choix : l'option choisie par le joueur (numéro du challenge).
    - Joueur[] joueur : tableau des joueurs.
    - Round round : objet représentant l'état actuel de la partie.
    - ScoreFinal[] final : tableau des scores finaux des joueurs.
    - int idJoueur : identifiant du joueur qui effectue l'action.
    Local: 
    - bool valide : variable indiquant si le challenge a été effectué avec succès.
    - int index : index pour parcourir la liste des challenges restants du joueur.
    Sortie: 
    - bool valide : vrai si le challenge a été effectué avec succès, sinon faux.
  Fonction choixChall(int choix, Joueur[] joueur, Round round, ScoreFinal[] final, int idJoueur): bool
  */
  static bool choixChall(int choix ,Joueur[] joueur, Round round, ScoreFinal[] final,int idJoueur)
  {
    bool valide = false; // variable indiquant si le challenge a été effectué avec succès
    int index=0; // index pour parcourir les challenges restants du joueur

    switch (choix)
    {
      case 1:
          // Parcours des challenges restants du joueur pour vérifier la disponibilité du challenge "Nombre de 1".
          while (index < joueur[idJoueur].challengeRestant.Count)
          {
            if (joueur[idJoueur].challengeRestant[index].Equals("Nombre de 1"))
            {
              joueur[idJoueur].challengeRestant.RemoveAt(index); // Retirer le challenge de la liste des challenges restants du joueur.
              round.res[idJoueur].challenge = "Nombre de 1"; // Enregistrer le challenge dans la partie en cours.
              valide = true; // Le challenge a été effectué.
              
              // Calcul du score pour le challenge "Nombre de 1".
              int scoreAct = NombreDeX(round.res[idJoueur].de, 1);
              round.res[idJoueur].score = scoreAct;
              final[idJoueur].score += scoreAct; // Ajouter le score au total du joueur.
              joueur[idJoueur].sommemineur += scoreAct;
              
              // Vérifier si le joueur atteint le seuil de 63 pour le bonus.
              if (joueur[idJoueur].sommemineur >= 63 && final[idJoueur].bonus == 0)
              {
                final[idJoueur].bonus = 35;
                final[idJoueur].score += 35; // Ajouter le bonus de 35 points au score.
              }
            }
            else
            {
              index++; // Passer au challenge suivant si "Nombre de 1" n'est pas trouvé.
            }
          }
          if (!valide)
          {
            Console.WriteLine("challenge non disponible"); // Afficher un message si le challenge n'est pas disponible.
          }
      break;


      case 2:
          // Parcours des challenges restants du joueur pour vérifier la disponibilité du challenge "Nombre de 2".
          while (index < joueur[idJoueur].challengeRestant.Count)
          {
            if (joueur[idJoueur].challengeRestant[index].Equals("Nombre de 2"))
            {
              joueur[idJoueur].challengeRestant.RemoveAt(index); // Retirer le challenge de la liste des challenges restants.
              round.res[idJoueur].challenge = "Nombre de 2"; // Enregistrer le challenge dans la partie.
              valide = true; // Le challenge a été effectué.
              
              // Calcul du score pour le challenge "Nombre de 2".
              int scoreAct = NombreDeX(round.res[idJoueur].de, 2);
              round.res[idJoueur].score = scoreAct;
              final[idJoueur].score += scoreAct; // Ajouter le score au total du joueur.
              joueur[idJoueur].sommemineur += scoreAct;
              
              // Vérifier si le joueur atteint le seuil de 63 pour le bonus.
              if (joueur[idJoueur].sommemineur >= 63 && final[idJoueur].bonus == 0)
              {
                final[idJoueur].bonus = 35;
                final[idJoueur].score += 35; // Ajouter le bonus de 35 points.
              }
            }
            else
            {
              index++; // Passer au challenge suivant si "Nombre de 2" n'est pas trouvé.
            }
          }
          if (!valide)
          {
            Console.WriteLine("challenge non disponible"); // Afficher un message si le challenge n'est pas disponible.
          }
      break;


      case 3:
          // Parcours des challenges restants du joueur pour vérifier la disponibilité du challenge "Nombre de 3".
          while (index < joueur[idJoueur].challengeRestant.Count)
          {
            if (joueur[idJoueur].challengeRestant[index].Equals("Nombre de 3"))
            {
              joueur[idJoueur].challengeRestant.RemoveAt(index); // Retirer le challenge de la liste des challenges restants.
              round.res[idJoueur].challenge = "Nombre de 3"; // Enregistrer le challenge dans la partie.
              valide = true; // Le challenge a été effectué.
              
              // Calcul du score pour le challenge "Nombre de 3".
              int scoreAct = NombreDeX(round.res[idJoueur].de, 3);
              round.res[idJoueur].score = scoreAct;
              final[idJoueur].score += scoreAct; // Ajouter le score au total du joueur.
              joueur[idJoueur].sommemineur += scoreAct;
              
              // Vérifier si le joueur atteint le seuil de 63 pour le bonus.
              if (joueur[idJoueur].sommemineur >= 63 && final[idJoueur].bonus == 0)
              {
                final[idJoueur].bonus = 35;
                final[idJoueur].score += 35; // Ajouter le bonus de 35 points.
              }
            }
            else
            {
              index++; // Passer au challenge suivant si "Nombre de 3" n'est pas trouvé.
            }
          }
          if (!valide)
          {
            Console.WriteLine("challenge non disponible"); // Afficher un message si le challenge n'est pas disponible.
          }
      break;


      case 4:
          // Parcours des challenges restants du joueur pour vérifier la disponibilité du challenge "Nombre de 4".
          while (index < joueur[idJoueur].challengeRestant.Count)
          {
            if (joueur[idJoueur].challengeRestant[index].Equals("Nombre de 4"))
            {
              joueur[idJoueur].challengeRestant.RemoveAt(index); // Retirer le challenge de la liste des challenges restants.
              round.res[idJoueur].challenge = "Nombre de 4"; // Enregistrer le challenge dans la partie.
              valide = true; // Le challenge a été effectué.
              
              // Calcul du score pour le challenge "Nombre de 4".
              int scoreAct = NombreDeX(round.res[idJoueur].de, 4);
              round.res[idJoueur].score = scoreAct;
              final[idJoueur].score += scoreAct; // Ajouter le score au total du joueur.
              joueur[idJoueur].sommemineur += scoreAct;
              
              // Vérifier si le joueur atteint le seuil de 63 pour le bonus.
              if (joueur[idJoueur].sommemineur >= 63 && final[idJoueur].bonus == 0)
              {
                final[idJoueur].bonus = 35;
                final[idJoueur].score += 35; // Ajouter le bonus de 35 points.
              }
            }
            else
            {
              index++; // Passer au challenge suivant si "Nombre de 4" n'est pas trouvé.
            }
          }
          if (!valide)
          {
            Console.WriteLine("challenge non disponible"); // Afficher un message si le challenge n'est pas disponible.
          }
      break;


      case 5:
          // Parcours des challenges restants du joueur pour vérifier la disponibilité du challenge "Nombre de 5".
          while (index < joueur[idJoueur].challengeRestant.Count)
          {
            if (joueur[idJoueur].challengeRestant[index].Equals("Nombre de 5"))
            {
              joueur[idJoueur].challengeRestant.RemoveAt(index); // Retirer le challenge de la liste des challenges restants.
              round.res[idJoueur].challenge = "Nombre de 5"; // Enregistrer le challenge dans la partie.
              valide = true; // Le challenge a été effectué.
              
              // Calcul du score pour le challenge "Nombre de 5".
              int scoreAct = NombreDeX(round.res[idJoueur].de, 5);
              round.res[idJoueur].score = scoreAct;
              final[idJoueur].score += scoreAct; // Ajouter le score au total du joueur.
              joueur[idJoueur].sommemineur += scoreAct;
              
              // Vérifier si le joueur atteint le seuil de 63 pour le bonus.
              if (joueur[idJoueur].sommemineur >= 63 && final[idJoueur].bonus == 0)
              {
                final[idJoueur].bonus = 35;
                final[idJoueur].score += 35; // Ajouter le bonus de 35 points.
              }
            }
            else
            {
              index++; // Passer au challenge suivant si "Nombre de 5" n'est pas trouvé.
            }
          }
          if (!valide)
          {
            Console.WriteLine("challenge non disponible"); // Afficher un message si le challenge n'est pas disponible.
          }
      break;


      case 6:
          // Parcours des challenges restants du joueur pour vérifier la disponibilité du challenge "Nombre de 6".
          while (index < joueur[idJoueur].challengeRestant.Count)
          {
            if (joueur[idJoueur].challengeRestant[index].Equals("Nombre de 6"))
            {
              joueur[idJoueur].challengeRestant.RemoveAt(index); // Retirer le challenge de la liste des challenges restants.
              round.res[idJoueur].challenge = "Nombre de 6"; // Enregistrer le challenge dans la partie.
              valide = true; // Le challenge a été effectué.
              
              // Calcul du score pour le challenge "Nombre de 6".
              int scoreAct = NombreDeX(round.res[idJoueur].de, 6);
              round.res[idJoueur].score = scoreAct;
              final[idJoueur].score += scoreAct; // Ajouter le score au total du joueur.
              joueur[idJoueur].sommemineur += scoreAct;
              
              // Vérifier si le joueur atteint le seuil de 63 pour le bonus.
              if (joueur[idJoueur].sommemineur >= 63 && final[idJoueur].bonus == 0)
              {
                final[idJoueur].bonus = 35;
                final[idJoueur].score += 35; // Ajouter le bonus de 35 points.
              }
            }
            else
            {
              index++; // Passer au challenge suivant si "Nombre de 6" n'est pas trouvé.
            }
          }
          if (!valide)
          {
            Console.WriteLine("challenge non disponible"); // Afficher un message si le challenge n'est pas disponible.
          }
      break;


      case 7:
          // Parcours des challenges restants du joueur pour vérifier la disponibilité du challenge "Brelan".
          while (index < joueur[idJoueur].challengeRestant.Count)
          {
            if (joueur[idJoueur].challengeRestant[index].Equals("Brelan"))
            {
              joueur[idJoueur].challengeRestant.RemoveAt(index); // Retirer le challenge de la liste des challenges restants.
              round.res[idJoueur].challenge = "Brelan"; // Enregistrer le challenge dans la partie.
              valide = true; // Le challenge a été effectué.
              
              // Calcul du score pour le challenge "Brelan".
              int scoreAct = brelan(round.res[idJoueur].de);
              round.res[idJoueur].score = scoreAct;
              final[idJoueur].score += scoreAct; // Ajouter le score au total du joueur.
            }
            else
            {
              index++; // Passer au challenge suivant si "Brelan" n'est pas trouvé.
            }
          }
          if (!valide)
          {
            Console.WriteLine("challenge non disponible"); // Afficher un message si le challenge n'est pas disponible.
          }
      break;


      case 8:
          // Parcours des challenges restants du joueur pour vérifier la disponibilité du challenge "Carré".
          while (index < joueur[idJoueur].challengeRestant.Count)
          {
            if (joueur[idJoueur].challengeRestant[index].Equals("Carré"))
            {
              joueur[idJoueur].challengeRestant.RemoveAt(index); // Retirer le challenge de la liste des challenges restants.
              round.res[idJoueur].challenge = "Carré"; // Enregistrer le challenge dans la partie.
              valide = true; // Le challenge a été effectué.
              
              // Calcul du score pour le challenge "Carré".
              int scoreAct = carre(round.res[idJoueur].de);
              round.res[idJoueur].score = scoreAct;
              final[idJoueur].score += scoreAct; // Ajouter le score au total du joueur.
            }
            else
            {
              index++; // Passer au challenge suivant si "Carré" n'est pas trouvé.
            }
          }
          if (!valide)
          {
            Console.WriteLine("challenge non disponible"); // Afficher un message si le challenge n'est pas disponible.
          }
      break;


      case 9:
          // Parcours des challenges restants du joueur pour vérifier la disponibilité du challenge "Full".
          while (index < joueur[idJoueur].challengeRestant.Count)
          {
            if (joueur[idJoueur].challengeRestant[index].Equals("Full"))
            {
              joueur[idJoueur].challengeRestant.RemoveAt(index); // Retirer le challenge de la liste des challenges restants.
              round.res[idJoueur].challenge = "Full"; // Enregistrer le challenge dans la partie.
              valide = true; // Le challenge a été effectué.
              
              // Calcul du score pour le challenge "Full".
              int scoreAct = full(round.res[idJoueur].de);
              round.res[idJoueur].score = scoreAct;
              final[idJoueur].score += scoreAct; // Ajouter le score au total du joueur.
            }
            else
            {
              index++; // Passer au challenge suivant si "Full" n'est pas trouvé.
            }
          }
          if (!valide)
          {
            Console.WriteLine("challenge non disponible"); // Afficher un message si le challenge n'est pas disponible.
          }
      break;


      case 10:
          // Parcours des challenges restants du joueur pour vérifier la disponibilité du challenge "Petite Suite".
          while (index < joueur[idJoueur].challengeRestant.Count)
          {
            if (joueur[idJoueur].challengeRestant[index].Equals("Petite Suite"))
            {
              joueur[idJoueur].challengeRestant.RemoveAt(index); // Retirer le challenge de la liste des challenges restants.
              round.res[idJoueur].challenge = "Petite Suite"; // Enregistrer le challenge dans la partie.
              valide = true; // Le challenge a été effectué.
              
              // Calcul du score pour le challenge "Petite Suite".
              int scoreAct = petite(round.res[idJoueur].de);
              round.res[idJoueur].score = scoreAct;
              final[idJoueur].score += scoreAct; // Ajouter le score au total du joueur.
            }
            else
            {
              index++; // Passer au challenge suivant si "Petite Suite" n'est pas trouvé.
            }
          }
          if (!valide)
          {
            Console.WriteLine("challenge non disponible"); // Afficher un message si le challenge n'est pas disponible.
          }
      break;


      case 11:
          // Parcours des challenges restants du joueur pour vérifier la disponibilité du challenge "Grande Suite".
          while (index < joueur[idJoueur].challengeRestant.Count)
          {
            if (joueur[idJoueur].challengeRestant[index].Equals("Grande Suite"))
            {
              joueur[idJoueur].challengeRestant.RemoveAt(index); // Retirer le challenge de la liste des challenges restants.
              round.res[idJoueur].challenge = "Grande Suite"; // Enregistrer le challenge dans la partie.
              valide = true; // Le challenge a été effectué.
              
              // Calcul du score pour le challenge "Grande Suite".
              int scoreAct = grande(round.res[idJoueur].de);
              round.res[idJoueur].score = scoreAct;
              final[idJoueur].score += scoreAct; // Ajouter le score au total du joueur.
            }
            else
            {
              index++; // Passer au challenge suivant si "Grande Suite" n'est pas trouvé.
            }
          }
          if (!valide)
          {
            Console.WriteLine("challenge non disponible"); // Afficher un message si le challenge n'est pas disponible.
          }
      break;


      case 12:
          // Parcours des challenges restants du joueur pour vérifier la disponibilité du challenge "Yam's".
          while (index < joueur[idJoueur].challengeRestant.Count)
          {
            if (joueur[idJoueur].challengeRestant[index].Equals("Yam's"))
            {
              joueur[idJoueur].challengeRestant.RemoveAt(index); // Retirer le challenge de la liste des challenges restants.
              round.res[idJoueur].challenge = "Yam's"; // Enregistrer le challenge dans la partie.
              valide = true; // Le challenge a été effectué.
              
              // Calcul du score pour le challenge "Yam's".
              int scoreAct = yams(round.res[idJoueur].de);
              round.res[idJoueur].score = scoreAct;
              final[idJoueur].score += scoreAct; // Ajouter le score au total du joueur.
            }
            else
            {
              index++; // Passer au challenge suivant si "Yam's" n'est pas trouvé.
            }
          }
          if (!valide)
          {
            Console.WriteLine("challenge non disponible"); // Afficher un message si le challenge n'est pas disponible.
          }
      break;


      case 13:
          // Parcours des challenges restants du joueur pour vérifier la disponibilité du challenge "Chance".
          while (index < joueur[idJoueur].challengeRestant.Count)
          {
            if (joueur[idJoueur].challengeRestant[index].Equals("Chance"))
            {
              joueur[idJoueur].challengeRestant.RemoveAt(index); // Retirer le challenge de la liste des challenges restants.
              round.res[idJoueur].challenge = "Chance"; // Enregistrer le challenge dans la partie.
              valide = true; // Le challenge a été effectué.
              
              // Calcul du score pour le challenge "Chance".
              int scoreAct = chance(round.res[idJoueur].de);
              round.res[idJoueur].score = scoreAct;
              final[idJoueur].score += scoreAct; // Ajouter le score au total du joueur.
            }
            else
            {
              index++; // Passer au challenge suivant si "Chance" n'est pas trouvé.
            }
          }
          if (!valide)
          {
            Console.WriteLine("challenge non disponible"); // Afficher un message si le challenge n'est pas disponible.
          }
      break;


      default:
          Console.WriteLine("Le choix du challenge va de 1 a 13 :) "); // Afficher un message d'erreur si le choix du challenge est invalide.
      break;

    }
    return valide;
  }


  /*
      Procédure AfficherTabRound
          Idée: Affiche les informations des rounds et des joueurs dans chaque round.
          Entrée: TabRound (Round[]) - Un tableau de rounds contenant les résultats des joueurs.
          Local: i (int) - Compteur pour parcourir le tableau des rounds.
                j (int) - Compteur pour parcourir les résultats des joueurs dans chaque round.
                res (var) - Variable temporaire pour stocker les résultats d'un joueur dans un round.
          Sortie: void - Aucune valeur retournée.
      Procédure AfficherTabRound(TabRound)
  */
  static void AfficherTabRound(Round[] TabRound)
  {
      // Parcourt chaque round dans le tableau
      for (int i = 0; i < TabRound.Length; i++)
      {
          Console.WriteLine($"Round {i + 1}"); // Affiche le numéro du round

          // Parcourt les résultats des joueurs dans chaque round
          for (int j = 0; j < TabRound[i].res.Length; j++)
          {
              var res = TabRound[i].res[j]; // Récupère les résultats d'un joueur pour ce round
              Console.WriteLine($"  - Joueur {res.id_player}"); // Affiche l'ID du joueur
              Console.WriteLine($"    Dés: {string.Join(", ", res.de)}"); // Affiche les dés du joueur sous forme de chaîne
              Console.WriteLine($"    Challenge: {res.challenge}"); // Affiche le challenge réalisé par le joueur
              Console.WriteLine($"    Score: {res.score}"); // Affiche le score du joueur pour ce round
          }

          Console.WriteLine(); // Affiche une ligne vide entre les rounds
      }
  }


  /*
    Procédure Main
        Idée: Point d'entrée du programme, gère la boucle principale du jeu de Yams pour deux joueurs. 
              Initialise les joueurs, les rounds et les scores, puis gère les actions des joueurs à chaque round.
        Entrée: Aucun paramètre.
        Local: 
            - int jouer: Variable permettant de contrôler la boucle du jeu (1 pour continuer, 2 pour quitter).
            - Joueur[] TabJoueur: Tableau contenant les informations des joueurs.
            - Round[] TabRound: Tableau contenant les rounds de la partie.
            - ScoreFinal[] TabScoreFinal: Tableau contenant les scores finaux des joueurs.
            - int nbRound: Compteur de round, allant de 1 à 13.
            - int nbLancer: Compteur de lancés de dés pour chaque joueur.
            - int choix: Choix effectué par l'utilisateur pour différentes actions dans le jeu.
            - bool relance: Indicateur pour savoir si un joueur souhaite relancer ses dés.
            - bool valide, valide2: Variables de validation pour les entrées utilisateurs.
            - int[] positions: Tableau contenant les positions des dés à relancer.
            - string choixdes: Chaîne de caractères contenant les positions des dés à relancer.
        Sortie: Aucun (affiche le gagnant et les résultats sur la console).
    Procédure Main()
  */
  static void Main()
  {
      int jouer = 1; // Variable pour gérer la boucle de jeu
      while (jouer == 1) // Tant que l'utilisateur choisit de jouer
      {
          // Initialisation des joueurs, des rounds et des scores finaux
          Joueur[] TabJoueur = new Joueur[2]; // Tableau pour les 2 joueurs
          Round[] TabRound = new Round[13]; // Tableau pour les 13 rounds
          ScoreFinal[] TabScoreFinal = new ScoreFinal[] { new ScoreFinal(1, 0, 0), new ScoreFinal(2, 0, 0) }; // Initialisation du score final des joueurs

          // Initialisation des joueurs et des rounds
          InitialisationJoueur(TabJoueur);
          InitialisationRound(TabRound);

          int nbRound = 1; // Compteur pour le nombre de rounds
          int nbLancer = 0; // Compteur pour le nombre de lancers de dés
          int choix; // Variable pour stocker le choix de l'utilisateur
          bool relance = true; // Variable pour savoir si le joueur peut relancer ses dés
          bool valide = false; // Variable pour valider le choix du challenge
          bool valide2 = false; // Variable pour valider les positions des dés à relancer
          int[] positions = null; // Tableau pour stocker les positions des dés à relancer
          string choixdes; // Variable pour stocker les positions des dés à relancer

          // Boucle principale du jeu pour chaque round (1 à 13)
          while (nbRound <= 13)
          {
              Console.WriteLine(" \n-------------Round : " + nbRound + "-------------");

              // Boucle pour chaque joueur (de 0 à 1)
              for (int idJoueur = 0; idJoueur <= 1; idJoueur++)
              {
                  Console.WriteLine("-----------------------------------");

                  // Affichage des informations de début de tour pour chaque joueur
                  AffichageDebutTour(TabJoueur, TabRound, nbRound, idJoueur);

                  // Lancer les dés du joueur pour ce round
                  LancerDes(TabRound[nbRound - 1].res[idJoueur].de);

                  // Affichage des dés obtenus par le joueur
                  afficheDe(TabRound, nbRound - 1, idJoueur);

                  choix = 0;
                  relance = true;
                  nbLancer = 0;

                  // Boucle pour relancer les dés si nécessaire (maximum 2 lancers)
                  while (nbLancer < 2 && relance)
                  {
                      Console.WriteLine("Voulez vous relancez ? (si oui, indiquez la position des dés à relancer) \n \n1 - Relancer\n2 - Choix Challenge");

                      try
                      {
                          choix = int.Parse(Console.ReadLine()); // Récupération du choix de l'utilisateur
                          if (choix == 1)
                          {
                              valide2 = false; // Réinitialisation de la validation
                              positions = null; // Réinitialisation des positions des dés à relancer
                              // Demande à l'utilisateur quelles positions des dés relancer
                              while (!valide2)
                              {
                                  try
                                  {
                                      Console.WriteLine("\n Écrivez les positions des dés à relancer (ex: 1,3,4) : ");
                                      choixdes = Console.ReadLine();
                                      Console.WriteLine("\n");
                                      // Split la chaîne et la convertit en tableau d'entiers
                                      positions = choixdes.Split(',').Select(p => int.Parse(p)).ToArray();

                                      // Vérifie que les positions sont valides
                                      if (positions.All(pos => pos >= 1 && pos <= 5))
                                      {
                                          // Relance les dés correspondants
                                          RelanceDes(TabRound[nbRound - 1].res[idJoueur].de, choixdes);
                                          valide2 = true; // Sort de la boucle si tout est validé
                                      }
                                      else
                                      {
                                          Console.WriteLine("Les positions doivent être entre 1 et 5. Veuillez réessayer.");
                                      }
                                  }
                                  catch (Exception)
                                  {
                                      Console.WriteLine("Entrée invalide. Exemple attendu : 1,3,4 (positions entre 1 et 5). Veuillez réessayer.");
                                  }
                              }

                              // Affichage des dés après relance
                              afficheDe(TabRound, nbRound - 1, idJoueur);
                              nbLancer++; // Incrémente le nombre de lancers
                          }
                          else if (choix == 2)
                          {
                              relance = false; // L'utilisateur choisit de ne pas relancer et de passer au choix du challenge
                          }
                          else
                          {
                              Console.WriteLine("Veuillez rentrer un nombre entre 1 et 2 !!");
                              Console.WriteLine();
                          }
                      }
                      catch (System.FormatException)
                      {
                          Console.WriteLine("Veuillez rentrer un nombre entre 1 et 2 !!");
                          Console.WriteLine();
                      }
                  }

                  valide = false; // Réinitialisation de la validation avant le choix du challenge
                  Console.WriteLine();
                  Console.WriteLine("--------------------- CHALLENGE --------------------------");
                  Console.WriteLine();
                  Console.WriteLine("Choisissez un challenge parmi ceux qu'il vous reste :\n1 - Nombre de 1\n2 - Nombre de 2\n3 - Nombre de 3\n4 - Nombre de 4\n5 - Nombre de 5\n6 - Nombre de 6\n7 - Brelan\n8 - Carré\n9 - Full\n10 - Petite Suite\n11 - Grande Suite\n12 - Yam's\n13 - Chance \n \n");
                  Console.WriteLine("--------------------- CHALLENGE -------------------------- \n");

                  // Boucle pour choisir un challenge valide
                  while (!valide)
                  {
                      try
                      {
                          choix = int.Parse(Console.ReadLine()); // Récupère le choix de l'utilisateur
                          // Appelle la fonction de validation pour le challenge choisi
                          valide = choixChall(choix, TabJoueur, TabRound[nbRound - 1], TabScoreFinal, idJoueur);
                      }
                      catch (System.FormatException)
                      {
                          Console.WriteLine("Veuillez rentrer un nombre entre 1 et 13 !!");
                          Console.WriteLine();
                          Console.WriteLine();
                          Console.WriteLine("Choisissez un challenge :\n1 - Nombre de 1\n2 - Nombre de 2\n3 - Nombre de 3\n4 - Nombre de 4\n5 - Nombre de 5\n6 - Nombre de 6\n7 - Brelan\n8 - Carré\n9 - Full\n10 - Petite Suite\n11 - Grande Suite\n12 - Yam's\n13 - Chance");
                      }
                  }

                  // Affiche le résultat après le challenge
                  afficheResult(TabRound, TabScoreFinal, nbRound - 1, idJoueur);
              }
              nbRound++; // Passe au round suivant
          }

          // Affichage des résultats des rounds
          AfficherTabRound(TabRound);

          // Vérification du gagnant en fonction des scores finaux
          if ((TabScoreFinal[0].score + TabScoreFinal[0].bonus) > (TabScoreFinal[1].score + TabScoreFinal[1].bonus))
          {
              Console.WriteLine($"Le gagnant est {TabJoueur[0].pseudo} avec un score final de {TabScoreFinal[0].score} et un bonus de {TabScoreFinal[0].bonus}");
          }
          else if ((TabScoreFinal[0].score + TabScoreFinal[0].bonus) < (TabScoreFinal[1].score + TabScoreFinal[1].bonus))
          {
              Console.WriteLine($"Le gagnant est {TabJoueur[1].pseudo} avec un score final de {TabScoreFinal[1].score} et un bonus de {TabScoreFinal[1].bonus}");
          }
          else
          {
              Console.WriteLine("Égalité omg !");
          }

          // Sauvegarde des résultats dans un fichier JSON
          CreerJSON(TabJoueur, TabRound, TabScoreFinal);
          Console.WriteLine("Les résultats ont été sauvegardés dans yams.json.");

          // Demande à l'utilisateur s'il veut rejouer ou quitter
          Console.WriteLine("Voulez vous quitter ou rejouer une partie ?\n(Attention si vous rejouez les resultats de la partie précédente sera écrasé à la fin de la partie suivante !)\n1 - Rejouer\n2 - Quitter");
          jouer = int.Parse(Console.ReadLine()); // Récupère la réponse de l'utilisateur
      }
  }
}
