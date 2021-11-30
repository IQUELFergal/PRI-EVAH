# Manuel Utilisateur 
#### Réalisé dans le cadre du stage assistant Ingénieur S8 par Le Gall Marine 


## L'architecture du projet  

- Request.cs : le fichier central du projet. Il est relié au Player dans Unity 
- Textproduct.cs : il est placé sur la nourriture et sert à l'affichage des textes d'indentification des produits 
- Stopcondition.cs : à mettre sur tout les objets dont on aura besoin d'intéragir avec pendant le scénario
- classesAPI.cs :  comprend toute les classes necessaire au fonctionnement de l'api 
- Etiquette.cs : comportement des etiquettes
- Shelf.cs : comportement des étagères
- le dossier classMetier reprend toute les classes (une par fichier) du modèle métier  

## Le scénario 

Tout le scénario est décrit dans le fichier scenario.xml 
pour chaque étape il y a :  
- l'instruction : le texte pour indiquer la tache à faire qui sera indiqué sur l'écran de l'utilisateur 
- l'Objet : l'objet cible à mettre en evidance pour aider l'utilisateur 
- Ressources : l'image le cas échéant 
- Temps : le temps au bout duquel on passe à l'étape suivante (0 si indépendant du temps)
- Evenement : l'objet sur lequel est placé le fichier stopCondition

## La tablette et l'application Sequoia 

pour afficher l'application Sequoia sur la tablette dans l'environnement virtuel il faut lancer un serveur nodejs et lui 
rajouter une route et prend un screenshot à l'aide de puppeteer et renvoie cette image en base64. Il suffit juste alors de 
la decoder en byte et de la mettre en texture d'une image sur unity ensuite.

`npm install ` dans le dossier ou est le `package.json`

(`npm init adonis-ts-app@latest hello-world` pour recreer un dossier hello lié à adonis (mais déjà présent))

`npm run dev` dans le dossier hello world pour lancer le serveur 

les indications de code sont dans le README.md dans le dossier helloworld 

Pour l'instant on a une image fixe donc il faudra voir comment gerer l'interaction avec la tablette (pour l'instant 
l'image est flou) et voir comment remplir les formulaires 


## Les points en cours/restants 
 - les bactéries : le shader existe (DirtyShader) mais n'est pas appliqué pour l'instant
 - gestion des bactéries (si un objet est par terre ou lors du scénario)
 - gestion de l'interaction avec la tablette 
 

## Les points à améliorer
- dans le scénario la detection de prise de température est a vrai tout le temps 
- quelques problèmes pour l'ouverture/fermeture du frigo et des fours  
- modèle 3D des fours/ frigo à améliorer
- box collider + comportement des echelles de stockage 

