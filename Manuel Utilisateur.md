# Manuel Utilisateur 
#### R�alis� dans le cadre du stage assistant Ing�nieur S8 par Le Gall Marine 


## L'architecture du projet  

- Request.cs : le fichier central du projet. Il est reli� au Player dans Unity 
- Textproduct.cs : il est plac� sur la nourriture et sert � l'affichage des textes d'indentification des produits 
- Stopcondition.cs : � mettre sur tout les objets dont on aura besoin d'int�ragir avec pendant le sc�nario
- classesAPI.cs :  comprend toute les classes necessaire au fonctionnement de l'api 
- Etiquette.cs : comportement des etiquettes
- Shelf.cs : comportement des �tag�res
- le dossier classMetier reprend toute les classes (une par fichier) du mod�le m�tier  

## Le sc�nario 

Tout le sc�nario est d�crit dans le fichier scenario.xml 
pour chaque �tape il y a :  
- l'instruction : le texte pour indiquer la tache � faire qui sera indiqu� sur l'�cran de l'utilisateur 
- l'Objet : l'objet cible � mettre en evidance pour aider l'utilisateur 
- Ressources : l'image le cas �ch�ant 
- Temps : le temps au bout duquel on passe � l'�tape suivante (0 si ind�pendant du temps)
- Evenement : l'objet sur lequel est plac� le fichier stopCondition

## La tablette et l'application Sequoia 

pour afficher l'application Sequoia sur la tablette dans l'environnement virtuel il faut lancer un serveur nodejs et lui 
rajouter une route et prend un screenshot � l'aide de puppeteer et renvoie cette image en base64. Il suffit juste alors de 
la decoder en byte et de la mettre en texture d'une image sur unity ensuite.

`npm install ` dans le dossier ou est le `package.json`

(`npm init adonis-ts-app@latest hello-world` pour recreer un dossier hello li� � adonis (mais d�j� pr�sent))

`npm run dev` dans le dossier hello world pour lancer le serveur 

les indications de code sont dans le README.md dans le dossier helloworld 

Pour l'instant on a une image fixe donc il faudra voir comment gerer l'interaction avec la tablette (pour l'instant 
l'image est flou) et voir comment remplir les formulaires 


## Les points en cours/restants 
 - les bact�ries : le shader existe (DirtyShader) mais n'est pas appliqu� pour l'instant
 - gestion des bact�ries (si un objet est par terre ou lors du sc�nario)
 - gestion de l'interaction avec la tablette 
 

## Les points � am�liorer
- dans le sc�nario la detection de prise de temp�rature est a vrai tout le temps 
- quelques probl�mes pour l'ouverture/fermeture du frigo et des fours  
- mod�le 3D des fours/ frigo � am�liorer
- box collider + comportement des echelles de stockage 

