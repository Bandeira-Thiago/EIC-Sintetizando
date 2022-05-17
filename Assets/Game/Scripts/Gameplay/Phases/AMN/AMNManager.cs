using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

using PhasePart.RNA.DNA;
using GameUserInterface.Text;

//Unity Lerp

namespace PhasePart.AMN{
    //Before it was part of the InputPhase sons, but its not needed anymore
    public class AMNManager : PhaseManagerMono{
        [System.Serializable]
        private class AMNDescriber{
            public AMN value; //A,G,U,C
            public GameObject table = null; //One quarter of the aminoacids circle
        }

        [Space]
        [Header("AMN Manager Atributes")]
        [Space]
<<<<<<< Updated upstream

        [SerializeField] List<AMNDescriber> basics; //The "tables" and their anwsers
        private GameObject actualTable = null;

=======

        [SerializeField] List<AMNDescriber> basics = default; //The "tables" and their anwsers
        private GameObject actualTable = null;

>>>>>>> Stashed changes
        [SerializeField] Letter letterPrefab = default;
        [SerializeField] Transform letterSpawn = default;

        private static int numberOfAMN = 7; 
        private int actualCompleted = 0; 
        private const int ribossomeMaxNumber = 3;

        private static int sizeAMN = 3;
        private static string RNAtoAMN; //Sub product of the RNASpawner completion
        private int indexOfRNA = 0; //RNA control of the position

        private string nameAMN; //Change in every input
        
<<<<<<< Updated upstream
        [SerializeField] GameObject visualAMN; //Where all the tables, the ribossome and the transporter will be
=======
        [SerializeField] GameObject visualAMN = default; //Where all the tables, the ribossome and the transporter will be
>>>>>>> Stashed changes
        [SerializeField] AMNQueue completedAMNstack = default; //Push a AMN when its ends


        private void Start() {
<<<<<<< Updated upstream
            //FindObjectOfType<DNAManager>(true).DNANucleusVisibility(false); It shrink it the DNAManager already
            
=======
>>>>>>> Stashed changes
            visualAMN.SetActive(true);
            SpawnAMN();
            SetAMN();
        }

        private void SpawnAMN(){
            int i;

            for(i = 0; i < sizeAMN; i++){
                Instantiate<Letter>(letterPrefab, letterSpawn);
                //Here i don't need the set position
            }
        }

        private void SetAMN(){
            int i;
            string RNAstring = "";

            for(i = 0; i < sizeAMN; i++){
                RNAstring += RNAtoAMN[indexOfRNA];
                letterSpawn.GetChild(i).GetComponent<Letter>().Setup(RNAtoAMN[indexOfRNA].ToString());
                indexOfRNA++;
            }

            completedAMNstack.NewAMNInLine(actualCompleted + ribossomeMaxNumber < numberOfAMN,actualCompleted.ToString());
            SearchAMN(RNAstring);
        }

        public static void SetRNAtoAMNString(string RNA){
            AMNManager.RNAtoAMN = RNA;
        }

        private void SearchAMN(string RNAstring){
            int i = 0;
            AMN perc;
            AMNDescriber hold;

            hold = basics.Find(x => {
                return x.value.GetValue() == RNAstring[i].ToString();
            }); 

            if(actualTable != null){
                actualTable.SetActive(false);
            }
            
            perc = hold.value;
            actualTable = hold.table;
            actualTable.SetActive(true);

            if(actualTable != null){
                actualTable.SetActive(false);
            }
            
            actualTable = basics[i].table;
            actualTable.SetActive(true);

            for(i = 1; i < sizeAMN; i++){

                perc = perc.GetNexts().Find(x => {
                    return Array.Find(x.GetValue().Split(','), y => {
                        return y == RNAstring[i].ToString();
                    }) != null;
                });
            }

            nameAMN = perc.GetAMN(0).GetValue().ToUpper();
            print(nameAMN);
            //ShowAMN(RNAstring); Test
        }

        public bool VerifyAMN(string AMN){
            if(AMN.ToUpper() == nameAMN.ToUpper()){
                actualCompleted++;
                EndPhase();

                return true;
            }

            return false;
        }

        private void ShowAMN(string phrase){
            int i = 0;

            foreach(Transform child in letterSpawn){
                child.GetComponent<Letter>().Setup(phrase[i].ToString());
                i++;
            }
        }

        public new void EndPhase(){
            if(actualCompleted == numberOfAMN){
                //Here its change phases
                print("ENTROU");
                base.EndPhase();
                return;
            }
            //Move the string to the left
            
            SetAMN();
            return;
        }

        public static int GetSizeAMN(){
            return sizeAMN;
        }

        public static int GetNumberOfAMN(){
            return numberOfAMN;
        }

    }
}

/*
    private void SetLetterAMN(){ //Not used anymore
        int i;

        actualDesc = UnityEngine.Random.Range(0, basics.Count);

        string structure = basics[actualDesc].value.GetValue();
        string[] hold;

        AMN perc = basics[actualDesc].value;

        for(i = 1; i < sizeAMN; i++){
            perc = perc.GetAMN(UnityEngine.Random.Range(0, perc.GetNextsCount()));
            hold = perc.GetValue().Split(','); //Can be more than one value
            structure += hold[UnityEngine.Random.Range(0, hold.Length)];
        }

        nameAMN = perc.GetAMN(0).GetValue(); //Aminoacid
        ShowAMN(structure);
    }
*/
