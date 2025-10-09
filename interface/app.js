//###########################################################//
// Gestion du formulaire pour récupérer le code de la partie //
//###########################################################//

const input = document.querySelector('input');
const formulaire = document.querySelector('form');
let CodeGame = 0;

formulaire.addEventListener('submit', (event)=>{
    event.preventDefault(); 
    CodeGame = input.value;
    console.log(CodeGame);
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

//#######################################################//
// Fonction main qui gère le chargement de toute la page //
//#######################################################//

function main(){
    initHTML();
    displayName();
    finalResult();
}

//#######################################################################################################################################//
// Fonction initHTML : gère l'implémentation de toute les div class round qui seront remplit au fur et à mesure du chargement de la page //
//#######################################################################################################################################//

function initHTML(){
    const section = document.querySelector('section');

    for(let i = 0; i<=13; i++){
        if (i != 13){ 
            CodeHtml = `
            <div class="round">
                <h3></h3>

                <h4></h4>
                <section></section>

                <h4></h4>
                <section></section>
            </div>
            `;
            section.innerHTML += CodeHtml;
            displayRound(i+1);
        }
        else{
            CodeHtml = `
            <div class="round">
            <hr>
            <h3>Score final</h3>
            <hr>
            <div class="container">
                <!-- Inforation sur le score final du joueur 1-->
                <article>
                    <h4></h4>
                    <section></section>
                </article>
                <!-- Inforation sur le score final du joueur 2-->
                <article>
                    <h4></h4>
                    <section></section>
                </article>
            </div>
            </div>
            `;
            section.innerHTML += CodeHtml;
        }
    }
    
} 

//###########################################################################################################################//
// Fonction displayRound : affiche les information du round dont le numéro est donné par la variable 'index' mit en paramètre//
//###########################################################################################################################//

function displayRound(index){
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
         const p1 = document.querySelector(`.round:nth-of-type(${index}) section:nth-of-type(1)`);
         const p2 = document.querySelector(`.round:nth-of-type(${index}) section:nth-of-type(2)`);
         const round = document.querySelector(`.round:nth-of-type(${index}) h3`);
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
         round.innerHTML = CodeHtmlRound
     })
     .catch (error => {
         console.error('Erreur de chargement du personnage', error);
     })
}

//##########################################################################################//
// Fonction displayName : affiche les prénoms des joueurs dans chacunes des div class round //
//##########################################################################################//

function displayName(){
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
                const p1Name = document.querySelectorAll('.round h4:nth-of-type(1)');
                const p2Name = document.querySelectorAll('.round h4:nth-of-type(2)');
                const p1NameFinalScore = document.querySelector('.container article:nth-of-type(1) h4');
                const p2NameFinalScore = document.querySelector('.container article:nth-of-type(2) h4');
                CodeHtml = `${data[0].pseudo}`;
                CodeHtml2 = `${data[1].pseudo}`;
                CodeHtmlFinalScore1 = `${data[0].pseudo}`;
                CodeHtmlFinalScore2 = `${data[1].pseudo}`;

                for(let i =0 ; i<13; i++){
                    p1Name[i].innerHTML = CodeHtml;
                    p2Name[i].innerHTML = CodeHtml2;
                }

                p1NameFinalScore.innerHTML = CodeHtmlFinalScore1;
                p2NameFinalScore.innerHTML = CodeHtmlFinalScore2;
            })
            .catch (error => {
                console.error('Erreur', error);
            })
}

//##############################################################################//
// Fonction finalResult : charge le score final des 2 joueurs dans la page html //
//##############################################################################//

function finalResult(){
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
        const FinalResultP1 = document.querySelector('.container article:nth-of-type(1) section');
        const FinalResultP2 = document.querySelector('.container article:nth-of-type(2) section');

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