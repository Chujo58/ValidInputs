using System;

/*PHRASES IMPORTANTES:

Votre entier est trop petit: il doit être (d'au moins) (strictement supérieur à) min

Votre entier est trop grand: il doit être (d'au plus) (strictement inférieur à) max

Votre entier est trop petit/grand par rapport à l'intervalle demandé: il doit être compris ENTRE min et max (bornes exclues)

Votre entier est trop petit/grand par rapport à l'intervalle demandé: il ne peut valoir que de min à max (bornes incluses)*/


class SaisiesConsoleValides {
    private static int SaisirEntierConsole(bool ilYAUnMin, bool ilYAUnMax, bool strict, int min, int max, string specContrainte) {
        /*Méthode PRIVÉE, donc non accessible à l'extérieur de la classe. La méthode s'assure de demander à l'usager d'inscrire
        un entier, et tant que l'usager n'a pas inscrit un entier valide (ex.: "12a" n'est pas un entier valide!), la méthode
        redemande à l'usager de recommencer. De plus, SI l'entier doit être inscrit dans un certain intervalle, la méthode se
        charge de s'assurer que l'entier est bien compris entre les minimum et maximum passés en paramètre*/
        bool toutEstCorrect;
        int réponse = 0; //Initiliation par défaut
        string saisieConsole;
        string messageDErreur;
        string spécificationContrainte = specContrainte.Length == 0 ? "" : " CONTRAINTE! l'entier doit " + specContrainte + ".";
        Console.WriteLine("Veuillez svp inscrire un entier." + spécificationContrainte);
        do {
            messageDErreur = ""; //Initiliation (ou réinitiliation) par défaut
            saisieConsole = Console.ReadLine();
            try {
                réponse = Int32.Parse(saisieConsole);
                if (ilYAUnMin || ilYAUnMax){
                    bool tropPetit = strict ? réponse <= min : réponse < min;
		            bool tropGrand = strict ? réponse >= max : réponse > max;
		            if (ilYAUnMin && ilYAUnMax) {
			            if (tropPetit || tropGrand)
                            messageDErreur = spécificationContrainte;
		            } else if (ilYAUnMin){
			            if (tropPetit)
                       	   messageDErreur = spécificationContrainte;
                    } else if (tropGrand)
                       	   messageDErreur = spécificationContrainte;
                }		
            }
            catch {
                messageDErreur = "Votre entier n'est pas valide.";
            }

	        toutEstCorrect = messageDErreur.Length == 0;

            if (!toutEstCorrect) {
                messageDErreur += " Veuillez recommencez svp: ";
                Console.Write(messageDErreur);
            }
        } while (!toutEstCorrect);
        return réponse;
    }

    public static int SaisirEntierConsole() {
        /*Méthode publique, donc accessible de l'extérieur de la classe. Redirige le travail à la méthode privée
        SaisirEntierConsole ci-haut, en ne spécifiant aucune contrainte au niveau des arguments*/
        return SaisirEntierConsole(false, false, false, 0, 0, "");
        //Les 0 sont des valeurs par défaut, non applicables s'il n'y a pas d'intervalle
    }

    public static int SaisirEntierConsolePlusGrandQue(int valeurMinimale) {
        /*Méthode publique, donc accessible de l'extérieur de la classe. Redirige le travail à la méthode privée
        SaisirEntierConsole ci-haut, en spécifiant les bons arguments pour ce contexte*/
        return SaisirEntierConsole(true, false, true, valeurMinimale, 0, "être strictement supérieur à " + valeurMinimale);
    }

    public static int SaisirEntierConsoleAuMoins(int valeurMin) {
        /*Méthode publique, donc accessible de l'extérieur de la classe. Redirige le travail à la méthode privée
        SaisirEntierConsole ci-haut, en spécifiant les bons arguments pour ce contexte*/
        return SaisirEntierConsole(true, false, false, valeurMin, 0, "être d'au moins " + valeurMin);
    }

    public static int SaisirEntierConsolePlusPetitQue(int valeurMaximale) {
        /*Méthode publique, donc accessible de l'extérieur de la classe. Redirige le travail à la méthode privée
        SaisirEntierConsole ci-haut, en spécifiant les bons arguments pour ce contexte*/
        return SaisirEntierConsole(false, true, true, 0, valeurMaximale, "être strictement inférieur à " + valeurMaximale);
    }

    public static int SaisirEntierConsoleAuPlus(int valeurMax) {
        /*Méthode publique, donc accessible de l'extérieur de la classe. Redirige le travail à la méthode privée
        SaisirEntierConsole ci-haut, en spécifiant les bons arguments pour ce contexte*/
        return SaisirEntierConsole(false, true, false, 0, valeurMax, "être d'au plus " + valeurMax);
    }

    public static int SaisirEntierConsoleEntre(int borneMinimale, int borneMaximale) {
        /*Méthode publique, donc accessible de l'extérieur de la classe. Redirige le travail à la méthode privée
        SaisirEntierConsole ci-haut, en spécifiant les bons arguments pour ce contexte. Il y a cette fois un intervalle.*/
        return SaisirEntierConsole(true, true, true, borneMinimale, borneMaximale, "être compris ENTRE " + borneMinimale + " et " + borneMaximale);
    }

    public static int SaisirEntierConsoleDeA(int borneMin, int borneMax) {
        /*Méthode publique, donc accessible de l'extérieur de la classe. Redirige le travail à la méthode privée
        SaisirEntierConsole ci-haut, en spécifiant les bons arguments pour ce contexte. Il y a un intervalle.*/
        return SaisirEntierConsole(true, true, false, borneMin, borneMax, "aller de " + borneMin + " à " + borneMax + " inclusivement");
    }

    public static int SaisirEntierConsolePositifOuNul() {
        //Méthode publique, donc accessible de l'extérieur de la classe. Redirige le travail à une AUTRE méthode publique.
        return SaisirEntierConsoleAuMoins(0);
    }

    public static int SaisirEntierConsoleStrictementPositif() {
        //Méthode publique, donc accessible de l'extérieur de la classe. Redirige le travail à une AUTRE méthode publique.
        return SaisirEntierConsolePlusGrandQue(0);
    }

    public static int SaisirEntierConsoleNégatifOuNul() {
        //Méthode publique, donc accessible de l'extérieur de la classe. Redirige le travail à une AUTRE méthode publique.
        return SaisirEntierConsoleAuPlus(0);
    }

    public static int SaisirEntierConsoleStrictementNégatif() {
        //Méthode publique, donc accessible de l'extérieur de la classe. Redirige le travail à une AUTRE méthode publique.
        return SaisirEntierConsolePlusPetitQue(0);
    }


    public static bool SaisirReponseOuiNon(string questionQuiAppelleOuiNon) {
        /*Méthode utile pour tout contexte où on veut demander à l'usager une question qui appelle "oui ou "non" comme
        réponse. La méthode prend en paramètre la question, LUI AJOUTE UN " o/n:" pour bien spécifier à l'uager que c'est
        ainsi qu'il doit répondre, puis capte la réponse de l'usager. Tant que l'usager n'a pas répondu correctement, la
        méthode lui signifie qu'il doit répondre par un seul caractère:`'o' ou 'n' (ou 'O' ou 'N': les majuscules sont
        acceptées!), et demande à l'usager de "recommencer" sa réponse. La méthode retourne vrai ou faux selon que l'usager
        a répondu... oui ou non!*/
        bool toutEstCorrect;
        bool réponseEstOui = true; //Initiliation par défaut
        string messageDErreur, saisieConsole;
        char premierCaractère;
        Console.Write(questionQuiAppelleOuiNon + " o/n: ");
        do {
	    messageDErreur = ""; //Initiliation (ou réinitiliation) par défaut
            saisieConsole = Console.ReadLine();
            if (saisieConsole.Length == 1) {
                premierCaractère = saisieConsole.ToLower()[0];
                réponseEstOui = premierCaractère == 'o';
                if (!réponseEstOui && (premierCaractère != 'n')) messageDErreur = "Votre réponse doit absolument être 'o' ou 'n'(la lettre majuscule est permise).";
            }
            else {
                messageDErreur = "Une saisie valide dans ce cas implique un seul caractère, soit le premier de \"oui\" ou \"non\"!";
            }

	    toutEstCorrect = messageDErreur.Length == 0;

            if (!toutEstCorrect) {
                messageDErreur += " Recommencez svp: ";
                Console.WriteLine(messageDErreur);
            }
        } while (!toutEstCorrect);
        return réponseEstOui;
    }
}