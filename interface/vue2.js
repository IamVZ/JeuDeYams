//###########################################################//
// Gestion du formulaire pour récupérer le code de la partie //
//###########################################################//

const input = document.querySelector('input');
const formulaire = document.querySelector('form');
let CodeGame =0;

formulaire.addEventListener('submit', (event)=>{
    event.preventDefault(); 
    CodeGame = input.value;
    document.querySelector('button:nth-of-type(1)').style.opacity = 0.3; // griser le bouton gauche dès le chargement de la page
    main();
})

// Tableau de chaine de charactère contenant les codes html des images des Dés //
const desImg = [
    '<img src="img/1.PNG" alt="dé 1">',
    '<img src="img/2.PNG" alt="dé 2">',
    '<img src="img/3.PNG" alt="dé 3">',
    '<img src="img/4.PNG" alt="dé 4">',
    '<img src="img/5.PNG" alt="dé 5">',
    '<img src="img/6.PNG" alt="dé 6">',
]


let index = 1; //définition de la variable globale index qui servira de repère pour naviguer entre les différents rounds

function main(){

    index = 1; // initialisation de la varible globale index à 1 pour afficher le premier round dès le chargement de la page

    //###############################################################################################################################################//
    // Requête permettant d'afficher les prénoms des joueurs car ce sont des données qui ne bougeront pas au cour de la naviguation entre les rounds //
    //###############################################################################################################################################//

    fetch(`http://yams.iutrs.unistra.fr:3000/api/games/${CodeGame}/players`)
            .then(response => {
                if (!response.ok) {
                 //Code pour gérer le cas où la réponse n'est pas correcte
                 throw new Error('Erreur !'); //Le fetch s'arrête !
                 }
                // Retourner le résultat au format JSON si réponse correcte
                 return response.json();
            })
            .then (data => {
                const p1Name = document.querySelector('.round h4:nth-of-type(1)');
                const p2Name = document.querySelector('.round h4:nth-of-type(2)');
                const p1NameFooter = document.querySelector('.container article:nth-of-type(1) h4');
                const p2NameFooter = document.querySelector('.container article:nth-of-type(2) h4');
                CodeHtml = `${data[0].pseudo}`;
                CodeHtml2 = `${data[1].pseudo}`;
                CodeHtmlFooter1 = `${data[0].pseudo}`;
                CodeHtmlFooter2 = `${data[1].pseudo}`;
                p1Name.innerHTML = CodeHtml;
                p2Name.innerHTML = CodeHtml2;
                p1NameFooter.innerHTML = CodeHtmlFooter1;
                p2NameFooter.innerHTML = CodeHtmlFooter2;
            })
            .catch (error => {
                console.error('Erreur', error);
            })
       
    displayRound(); // Affiche le Premier Round 
    
    //##########################//
    // Affichage du Score Final //
    //##########################//

    fetch(`http://yams.iutrs.unistra.fr:3000/api/games/${CodeGame}/final-result`)
        .then(response => {
            if (!response.ok) {
             //Code pour gérer le cas où la réponse n'est pas correcte
             throw new Error('Erreur !'); //Le fetch s'arrête !
             }
            // Retourner le résultat au format JSON si réponse correcte
             return response.json();
        })
        .then (data => {
            const FinalResultP1 = document.querySelector('footer article:nth-of-type(1) section');
            const FinalResultP2 = document.querySelector('footer article:nth-of-type(2) section');

            CodeHtmlFinalResultP1 = `
                <p> point bonus obtenu : ${data[0].bonus} </p>
                <p> score : ${data[0].score} </p>
                <p> Total : ${data[0].bonus + data[0].score} </p>
            `;
            CodeHtmlFinalResultP2 = `
                <p> point bonus obtenu : ${data[1].bonus} </p>
                <p> score : ${data[1].score} </p>
                <p> Total : ${data[1].bonus + data[1].score} </p>
            `;

            FinalResultP1.innerHTML = CodeHtmlFinalResultP1;
            FinalResultP2.innerHTML = CodeHtmlFinalResultP2; 
        })
        .catch (error => {
            console.error('Erreur de chargement du personnage', error);
        })   
}

//#########################################//
// Gestion des évènements du bouton gauche //
//#########################################//

const buttonLeft = document.querySelector('button');
const buttonRight = document.querySelector('button:nth-of-type(2)');

buttonLeft.addEventListener('click', ()=>{
    if(index != 1)
    {
        index = index-1;
        if(index == 1)
        {
            document.querySelector('button:nth-of-type(1)').style.opacity = 0.3;
        }
        if(index != 13)
        {
            document.querySelector('button:nth-of-type(2)').style.opacity = 1;
        }
    }
    displayRound();
})

//########################################//
// Gestion des évènements du bouton droit //
//########################################//

buttonRight.addEventListener('click', ()=>{
    if(index != 13)
        {
            index = index+1;
            if(index == 13)
            {
                document.querySelector('button:nth-of-type(2)').style.opacity = 0.3;
            }
            if(index != 1)
            {
                document.querySelector('button:nth-of-type(1)').style.opacity = 1;
            }
        }
        displayRound();
})


//###########################################//
// Affichage des rounds grâce à displayRound //
//###########################################//

function displayRound(){
    fetch(`http://yams.iutrs.unistra.fr:3000/api/games/${CodeGame}/rounds/${index}`)
     .then(response => {
         if (!response.ok) {
          //Code pour gérer le cas où la réponse n'est pas correcte
          throw new Error('Erreur !'); //Le fetch s'arrête !
          }
         // Retourner le résultat au format JSON si réponse correcte
          return response.json();
     })
     .then (data => {
         const p1 = document.querySelector('.round section:nth-of-type(1)');
         const p2 = document.querySelector('.round section:nth-of-type(2)');
         const round = document.querySelector('.round h3');
         let Tab_De_J1 = [];
         let Tab_De_J2 = [];
         for(let i=0; i<5; i++)
         {
             Tab_De_J1.push(desImg[(data.results[0].dice[i])-1]);
         }
         for(let i=0; i<5; i++)
         {
             Tab_De_J2.push(desImg[(data.results[1].dice[i])-1]);
         }
         CodeHtml = `
             ${Tab_De_J1[0]} ${Tab_De_J1[1]} ${Tab_De_J1[2]} ${Tab_De_J1[3]} ${Tab_De_J1[4]}
             <p> challenge choisit : ${data.results[0].challenge} </p>
             <p> score : ${data.results[0].score} </p>
         `;
         CodeHtml2 = `
             ${Tab_De_J2[0]} ${Tab_De_J2[1]} ${Tab_De_J2[2]} ${Tab_De_J2[3]} ${Tab_De_J2[4]}
             <p> challenge choisit : ${data.results[1].challenge} </p>
             <p> score : ${data.results[1].score} </p>
         `;
         CodeHtmlRound = `Round ${index}`;
         p1.innerHTML = CodeHtml;
         p2.innerHTML = CodeHtml2;
         round.innerHTML = CodeHtmlRound;
     })
     .catch (error => {
         console.error('Erreur de chargement', error);
     })
}

