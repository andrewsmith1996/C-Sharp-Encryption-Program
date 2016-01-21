using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

//Main Class for flow of program
class mainFlow {
  public static void Main(string[] args){
      bool validSwitch = false;
      string userMenuChoice = ""; //Empty character literal

      while (validSwitch == false){
            Console.Clear();

            //Displays the menu
            Console.WriteLine("PDS Encryption Tool");
            Console.WriteLine("-------------------");
            Console.WriteLine("1 - Encrypt");
            Console.WriteLine("2 - Decrypt");
            Console.WriteLine("Q - Quit");
            Console.WriteLine("-------------------");

            //Gets the user choice
            userMenuChoice = Console.ReadLine().ToUpper();

            //Loop to validate the input
            if (userMenuChoice.Length != 0){
                if ((userMenuChoice == "1") || (userMenuChoice == "2") || (userMenuChoice == "Q"))
                {
                    break;
                }
                 else {
                    continue;
                } //End of userMenuChoice Validation loop
            }  //End of validSwitch loop
            else{
                Console.WriteLine("error");
            }
        }

      //Switch to call correct class
      switch (userMenuChoice){
          case "1":
              Console.Clear();
              encryptionClass encrpytionClassObject = new encryptionClass();
              string choice = "";
              while(true){
                  try{
                      Console.Clear();
                      Console.WriteLine("----------------");
                      Console.WriteLine("1 - Caesar Cipher (optional Cipher Text)");
                      Console.WriteLine("2 - Affine Cipher");
                      Console.WriteLine("----------------");

                      choice = Console.ReadLine();
                      if ((choice == "1" || choice == "2") && choice != ""){
                          break;
                      }
                  }
                    catch(Exception e){
                        Console.WriteLine(e.Message);
                    }
              }

              if (choice == "1"){
                  Console.Clear();
                  encrpytionClassObject.encryptionMainFlow();
              } else{
                  Console.Clear();
                  affineCipherClassEncrypt affineCipherClassObject = new affineCipherClassEncrypt();
                  affineCipherClassObject.affineCipherEncrypt();
              }


              break;
          case "2":
              Console.Clear();
              decryptionClass decrpytionClassObject = new decryptionClass();
              string choice1 = "";
              while(true){
                  Console.Clear();
                  Console.WriteLine("----------------");
                  Console.WriteLine("1 - Caesar Cipher (optional Cipher Text)");
                  Console.WriteLine("2 - Affine Cipher");
                  Console.WriteLine("----------------");

                  choice1 = Console.ReadLine();
                  if ((choice1 == "1" || choice1 == "2") && choice1 != ""){
                      break;
                  }
              }

              if (choice1 == "1"){
                  Console.Clear();
                  decrpytionClassObject.decrpytionMain();
              } else{
                  Console.Clear();
                  affineCipherClassDecrypt affineCipherClassObject = new affineCipherClassDecrypt();
                  affineCipherClassObject.affineCipherDecrypt();
              }


              break;
          case "Q":
                 Environment.Exit(0);
                  break;
          default:
              Console.WriteLine("Error");

              break;
      }//End of switch

  } //end of Main function
} //End of mainFlow class

//Class for encryption
class encryptionClass{
    public void encryptionMainFlow(){
      bool validSwitch = false;
      string menuChoice = "";
      int key;
      string userWord;


      while (validSwitch == false){
            Console.Clear();

            //Displays the menu
            Console.WriteLine("Encryption Tool");
            Console.WriteLine("----------------");
            Console.WriteLine("1 - User Chosen Key");
            Console.WriteLine("2 - Random Key");
            Console.WriteLine("Q - Quit");
            Console.WriteLine("----------------");

            //Gets the user choice
            menuChoice = Console.ReadLine().ToUpper();

            //Loop to validate the input
            if (menuChoice.Length != 0){
                if ((menuChoice == "1") || (menuChoice == "2") || (menuChoice == "Q")){
                    break;
                } else {
                    continue;
                } //End of menuChoice Validation loop
            }  //End of validSwitch loop
        }

      //Creates instance of the encryption class
      encryptionClass encrpytionClassObject = new encryptionClass();

      //Switch to call correct class
      switch (menuChoice){
          case "1":
              key = encrpytionClassObject.generateUserKey();
              break;
          case "2":
              key = encrpytionClassObject.generateRandomKey();

              break;
          case "Q":
                Environment.Exit(0);
                key = 0;
                break;
          default:
          key = 0;
              Console.WriteLine("Error");

              break;
      }//End of switch

    userWord = encrpytionClassObject.getUserWord();

    Console.WriteLine("Your Key is {0}", key);
    encrpytionClassObject.Encrypt(key, userWord);


    } //End of encryptionMain function

  public string getUserWord(){
      string userWord = "";

      while(true){
          Console.Clear();
          Console.WriteLine("Enter Sentence to Encrypt");
          userWord = Console.ReadLine().ToUpper();
          if (userWord != ""){
              break;
          }
      }

      return userWord;

  } //End of getUserWord method

  public int generateUserKey(){

    bool validSwitch2 = false;
    string key1 = "";
    int key = 0;
    //Validates the input of the key
    while (validSwitch2 == false){
          Console.Clear();
          Console.WriteLine("Enter Key");

          key1 = Console.ReadLine();

          //Loop to validate the input
          if ((key1 != "") && (Char.IsDigit(Convert.ToChar(key1)) == true)){
              key = Convert.ToInt16(key1);
              if ((key >= 1) && (key <= 26)){
                  break;
              } else {
                  continue;
              } //End of key Validation loop
          }
    }

    //If left shift then make the number minus


    return Convert.ToInt16(key);

  } //End of userKey method

  public int generateRandomKey(){
    int key;
    Random numberRef = new Random();
    key = numberRef.Next(0,27);

    return key;
  } //End of generateRandomKey method

  public void Encrypt(int key, string userWord){
      char[] alphabetList = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
      int countX;
      int countX1;
      string encryptedWord = "";
      Console.Clear();

      foreach(char characterCheck in userWord){ //Nested loop for looping through the encrypted message
            int pos = Array.IndexOf(alphabetList, characterCheck); //Locates the position of the character in the alphabet list
            if (key >= 0){
                countX = pos + key; //Creates the new reference for the letter, so the position + the KEY SHIFT
                if (countX >= 26){ //If we're at the end of the list...
                  countX = countX - 26; //Reset the count
                }

                if (Char.IsLetter(characterCheck) == false){ //If it's a space then add a space to the final string
                    encryptedWord = encryptedWord + characterCheck;
                }
                else{
                    encryptedWord = encryptedWord + alphabetList[countX]; //Adds the new letter to a new string
                }
            }
            else if (key < 0){
                countX1 = pos - key; //Creates the new reference for the letter, so the position + the KEY SHIFT
                if (countX1 <= 0){ //If we're at the end of the list...
                  countX1 = countX1 + 26; //Reset the count
                }

                if (characterCheck == ' '){ //If it's a space then add a space to the final string
                    encryptedWord = encryptedWord + ' ';
                }
                else{
                    encryptedWord = encryptedWord + alphabetList[countX1]; //Adds the new letter to a new string
                }
            }
      }
     string choice1 = "";
     char choice2 = '\0';
     while (true){
         Console.Clear();
         Console.WriteLine("Do you want to pass the message through a Cipher Alphabet? (Added Security) Y/N?");
         choice1 = Console.ReadLine().ToUpper();
         if (choice1 != ""){
             choice2 = Convert.ToChar(choice1);
             if ((Char.IsLetter(choice2) == true) && ((choice2 == 'Y') || (choice2 == 'N'))){
                 break;
             }
         }
     }

     string encryptedWordFinal;
     encryptionClass encryptionClassObject = new encryptionClass();
     if (choice1 == "Y"){
         encryptedWordFinal = encryptionClassObject.enigma(encryptedWord);
     } else {
         encryptedWordFinal = encryptedWord;
     }
     Console.Clear();
     Console.WriteLine("Your Encrypted Sentence: {0}", encryptedWordFinal);

     bool switch1 = false;
     char choice = '\0';
     string choice3 = "";
     while(switch1 != true){
         Console.Clear();
         Console.WriteLine("Write To Text File? Y/N");
         choice3 = Console.ReadLine().ToUpper();
         if (choice3 != ""){
             choice = Convert.ToChar(choice3);
             if (char.IsLetter(choice) == true){
                     break;
                 }
        }
    }

     switch(choice){
         case 'Y':
            Console.Clear();
            encryptionClassObject.writeToTextFile(encryptedWordFinal);
            break;
        case 'N':
            Console.Clear();
            break;
        default:
            Console.WriteLine("Error");
            break;
     }

 } //End of Encrypt method

  public void writeToTextFile(string encryptedWordFinal){
      string fileName = "";
      while(true){
         Console.Clear();
         Console.WriteLine("Enter File Name (No .txt extension)");
         fileName = Console.ReadLine();
         if (fileName != ""){
              fileName += ".txt";
              break;
         }
     }

    File.WriteAllText(fileName, encryptedWordFinal);
    Console.WriteLine("Successfully written to text file");

 } //End of writeToTextFile method

  public string enigma(string encryptedWord){
     char[] alphabetList = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
     char[] cipherList = {'V','N','C','I','Y','R','P','S','D','W','T','X','L','B','Z','G','U','F','H','K','E','A','J','M','Q','O'};
     string encryptedWordFinal = "";

     foreach(char x in encryptedWord){
         if (Char.IsLetter(x) == true){
             int pos = Array.IndexOf(alphabetList, x);
             encryptedWordFinal += cipherList[pos];
         } else{
             encryptedWordFinal += x;
         }
     }

     return encryptedWordFinal;
 } //End of enigma method
} //End of encryptionClass class

//Class for decryption
class decryptionClass{
    public void decrpytionMain(){
      Console.Clear();
      decryptionClass decrpytionClassObject = new decryptionClass();
      decrpytionClassObject.decrypt(); //Calls the decryption module for the actual decryption
    } //End of decryptionMain function

    public void decrypt(){
      int countX = 0;
      string fileName = "";

      while(true){
          Console.Clear();
          //Gets the user file name
          Console.WriteLine("Enter File Name (with .txt extension)");
          fileName = Console.ReadLine();
          if((fileName != "") && (File.Exists(fileName))){
              break;
          }
          else{
              Console.WriteLine("Please Enter a Valid Filename");
          }
      }

      //Loads the files contents into a string
      string fileContents = File.ReadAllText(fileName).ToUpper();

      fileContents = fileContents.Replace("\n", "");
      fileContents = fileContents.Replace("\r", "");

      //Asks whether the cipehr alphabet is needed
      Console.Clear();
      char choice1 = '\0';
      string choice4 = "";
      while (true){
          Console.Clear();
          Console.WriteLine("Do you want to pass the encoded message through a Cipher Alphabet? Y/N?");
          choice4 = Console.ReadLine().ToUpper();
          if (choice4 != ""){
              choice1 = Convert.ToChar(choice4);
              if (char.IsDigit(choice1) == false){
                  if ((Char.IsLetter(choice1) == true) && ((choice1 == 'Y') || (choice1 == 'N'))){
                      break;
                  }
              }
          }
      }

      //Switches between the cipher alphabet and the normal encryption
      string startMessage;
      if (choice1 == 'Y'){
          decryptionClass decryptionClassObject = new decryptionClass();
          startMessage = decryptionClassObject.enigmaDecrypt(fileContents);
      } else {
          startMessage = fileContents;
      }
      //Alphabet List for Reference
      char[] alphabetList = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};

      //Creates list to hold the possibilities
      Dictionary<string, int> decryptedPossibilites = new Dictionary<string, int>();

      //Main decryption loop
      for(int count = 1; count <= 26; count++){ //The KEY SHIFT count, right shift only of 1 - 26
         string newPossibility = ""; //Resets the possibility for each key shift
         foreach(char characterCheck in startMessage){ //Nested loop for looping through the encrypted message
             if (characterCheck == ' '){
                 newPossibility = newPossibility + ' ';
             } else {
               int pos = Array.IndexOf(alphabetList, characterCheck); //Locates the position of the character in the alphabet list
               countX = pos + count; //Creates the new reference for the letter, so the position + the KEY SHIFT
               if (countX >= 26){ //If we're at the end of the list...
                 countX = countX - 26; //Reset the count
             }

           if ((Char.IsLetter(characterCheck) == false) && (characterCheck != ' ')){ //If it's a space or other characte rthen add a the suitable character to the final string
                   newPossibility = newPossibility + characterCheck;
           }
           else{
             newPossibility = newPossibility + alphabetList[countX]; //Adds the new letter to a new string
           }
         }
     }

         decryptedPossibilites.Add(newPossibility, 26 - count); //Adds the possibiltiy to the list
     }

      //Loop for displaying all the possibilities
      Console.WriteLine("Possibilities:\n");

      foreach(KeyValuePair<string, int> entry in decryptedPossibilites){
        Console.WriteLine("KEY SHIFT: {0} \n{1}", (entry.Value), entry.Key);
        Console.WriteLine("");

      }

      //FREQUENCY ANALYSIS
      //Creates necessary dictionaries
      Dictionary<string, int> possibleMessagesCountE = new Dictionary<string, int>();
      Dictionary<string, int> possibleMessagesCountT = new Dictionary<string, int>();
      //Dictionary<string, int> possibleMessagesCountA = new Dictionary<string, int>();

      //Lists to hold the counts of letters
      List<int> eCountList = new List<int>();
      List<int> tCountList = new List<int>();
      List<int> aCountList = new List<int>();

     Console.WriteLine("----------------------------------------------");
     Console.WriteLine("----------------------------------------------");


     Console.WriteLine("Machine is thinking...");


     //These statements calculate the frequency of letters and add it to the necessary lists
     foreach(KeyValuePair<string, int> entry in decryptedPossibilites){
          int eCount = entry.Key.Split('E').Length - 1;
          possibleMessagesCountE.Add(entry.Key, eCount);
          eCountList.Add(eCount);

      }
     foreach(KeyValuePair<string, int> entry in decryptedPossibilites){
           int tCount = entry.Key.Split('T').Length - 1;
           possibleMessagesCountT.Add(entry.Key, tCount);
           tCountList.Add(tCount);

       }


      //Bubble sort algorithms for ordering the frequency
      int temp = 0;

      for (int write = 0; write < eCountList.Count; write++){
          for (int sort = 0; sort < eCountList.Count - 1; sort++){
              if (eCountList[sort] > eCountList[sort + 1]){
                  temp = eCountList[sort + 1];
                  eCountList[sort + 1] = eCountList[sort];
                  eCountList[sort] = temp;
                }
            }
        }

        temp = 0;

        for (int write = 0; write < tCountList.Count; write++){
            for (int sort = 0; sort < tCountList.Count - 1; sort++){
                if (tCountList[sort] > tCountList[sort + 1]){
                    temp = tCountList[sort + 1];
                    tCountList[sort + 1] = tCountList[sort];
                    tCountList[sort] = temp;
                  }
              }
          }

          temp = 0;
          for (int write = 0; write < aCountList.Count; write++){
              for (int sort = 0; sort < aCountList.Count - 1; sort++){
                  if (aCountList[sort] > aCountList[sort + 1]){
                      temp = aCountList[sort + 1];
                      aCountList[sort + 1] = aCountList[sort];
                      aCountList[sort] = temp;
                    }
                }
            }

      Console.WriteLine("Your Top Possibilities Based on Frequency Analysis Are:\n");
      Dictionary<string, int> freqList = new Dictionary<string, int>();

      //Prints the possibilities and the key shifts
      foreach(KeyValuePair<string, int> entry in possibleMessagesCountE){
          if(eCountList[eCountList.Count - 1] == entry.Value){
              Console.WriteLine(entry.Key);
              foreach(KeyValuePair<string, int> check in decryptedPossibilites){
                if(entry.Key == check.Key){
                    Console.WriteLine("KEY SHIFT: {0}", check.Value);
                    freqList.Add(entry.Key, check.Value);
                }
              }
              Console.WriteLine("");
          }
      }

      foreach(KeyValuePair<string, int> entry in possibleMessagesCountT){
          if(tCountList[tCountList.Count - 1] == entry.Value){
              Console.WriteLine(entry.Key);

              foreach(KeyValuePair<string, int> check in decryptedPossibilites){
                if(entry.Key == check.Key){
                    Console.WriteLine("KEY SHIFT: {0}", check.Value);
                    freqList.Add(entry.Key, check.Value);
                }
              }
              Console.WriteLine("");
          }
      }
      Console.WriteLine("----------------------------------------------");
      Console.WriteLine("----------------------------------------------");

      //Asks whether the user wants to output to a text file
      char choice2 = '\0';
      string choice5 = "";
      while (true){
          Console.WriteLine("Would you like to output to text file? Y/N?");
          choice5 = Console.ReadLine().ToUpper();
          if(choice5 != ""){
              choice2 = Convert.ToChar(choice5);
              if ((Char.IsLetter(choice2) == true) && ((choice2 == 'Y') || (choice2 == 'N'))){
                  break;
              }
          }
      }

      //Adds to a text file
      if (choice2 == 'Y'){
          if(File.Exists(@"Encryption Possibilities.txt")) //Checks if the file exists and if it does then delete it
          {
              File.Delete(@"Encryption Possibilities.txt");
          }
          foreach(KeyValuePair<string, int> entry in decryptedPossibilites){
              File.AppendAllText("Encryption Possibilities.txt", (entry.Key + ' ' + "Key Shift: " + entry.Value + '\n' + '\n'));
          }
          File.AppendAllText("Encryption Possibilities.txt", "Frequency Analysis Recommends:\n \n");

          foreach(KeyValuePair<string, int> entry in freqList){
              File.AppendAllText("Encryption Possibilities.txt", (entry.Key + ' ' + "Key Shift: " + entry.Value + '\n' + '\n'));
          }
        Console.WriteLine("Written to file");
      }

      //Asks if the user wants to output to a webpage
      char choiceHTML = '\0';
      string choiceHTML2 = "";

      while (true){
          Console.Clear();
          Console.WriteLine("Would you like to output to a Webpage? Y/N?");
          choiceHTML2 = Console.ReadLine().ToUpper();
          if(choiceHTML2 != ""){
              choiceHTML = Convert.ToChar(choiceHTML2);
              if ((Char.IsLetter(choiceHTML) == true) && ((choiceHTML == 'Y') || (choiceHTML == 'N'))){
                  break;
              }
          }
      }

      if (choiceHTML == 'Y'){
          if(File.Exists(@"Encryption Possibilities Webpage.html"))
          {
              File.Delete(@"Encryption Possibilities Webpage.html");
          }
          foreach(KeyValuePair<string, int> entry in decryptedPossibilites){
              File.AppendAllText("Encryption Possibilities Webpage.html", ("Key Shift: " + entry.Value + "<br>" + entry.Key + "<br>" + "<br>"));
          }
          File.AppendAllText("Encryption Possibilities Webpage.html", "Frequency Analysis Recommends: <br> <br>");

          foreach(KeyValuePair<string, int> entry in freqList){
              File.AppendAllText("Encryption Possibilities Webpage.html", (entry.Key + ' ' + "Key Shift: " + entry.Value + "<br>" + "<br>"));
          }
        Console.WriteLine("Written to Webpage");
      }


    } //End of decrypt method

    public string enigmaDecrypt(string newPossibility){
        Console.WriteLine("Before {0}", newPossibility);
        char[] alphabetList = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
        char[] cipherList =   {'V','N','C','I','Y','R','P','S','D','W','T','X','L','B','Z','G','U','F','H','K','E','A','J','M','Q','O'};
        string newPossibilityFinal = "";

        foreach(char x in newPossibility){
            if (Char.IsLetter(x) == true){
                int pos = Array.IndexOf(cipherList, x);
                newPossibilityFinal += alphabetList[pos];
            } else{
                newPossibilityFinal += x;
            }
        }

        Console.WriteLine("Before {0}", newPossibilityFinal);
        return newPossibilityFinal;
    } //end of enigmaDecrypt method
} //End of decryptionClass class

class affineCipherClassEncrypt{
    public void affineCipherEncrypt(){
        bool validSwitch = false;
        string encryptedWord = "";
        char[] alphabetList = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
        int[] keyListA = {1,3,5,7,9,11,15,17,19,21,23,25};
        string menuChoice = "";
        while (validSwitch == false){
              Console.Clear();

              //Displays the menu
              Console.WriteLine("Encryption Tool");
              Console.WriteLine("----------------");
              Console.WriteLine("1 - User Chosen Key");
              Console.WriteLine("2 - Random Key");
              Console.WriteLine("Q - Quit");
              Console.WriteLine("----------------");

              //Gets the user choice
              menuChoice = Console.ReadLine().ToUpper();


              //Loop to validate the input
              if (menuChoice.Length != 0){
                  if ((menuChoice == "1") || (menuChoice == "2") || (menuChoice == "Q")){
                     break;
                  } else {
                      continue;
                  } //End of menuChoice Validation loop
              }  //End of validSwitch loop
          }

          int a = 0;
          int b = 0;

          switch(menuChoice){
                case "1":
                while (true){
                    Console.Clear();
                    Console.WriteLine("Enter Value A");
                    a = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Enter Value B");
                    b = Convert.ToInt16(Console.ReadLine());

                    if (keyListA.Contains(a) == true && (b >= 1 && b <= 26)){
                        break;
                    }
                }
                break;

              case "2":
              Random Rnd = new Random();
              a = keyListA[Rnd.Next(0, 11)];
              b = Rnd.Next(0, 26);
              break;

              case "Q":
                Environment.Exit(0);
                break;


              default:
              Console.WriteLine("Error");
              a = 0;
              b = 0;
              break;
          }

          string text = "";
          while (true){
              Console.Clear();
              Console.WriteLine("Enter Text to Encrypt");
              text = Console.ReadLine().ToUpper();
              if (text != "" && text.Length != 1){
                  break;
              }
          }

          foreach(char x in text){
             if ((Char.IsLetter(x) == false) || (x == ' ')){ //If it's a space or other characte rthen add a the suitable character to the final string
                      encryptedWord += x;
            } else{
              int pos = Array.IndexOf(alphabetList, x);
              int newPos = (a * pos + b);
              newPos = (newPos%26 + 26)%26;
              encryptedWord += alphabetList[newPos];
          }
          }

        Console.WriteLine(encryptedWord);

        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("----------------------------------------------");


        char choice = '\0';
        string choice3 = "";
        while(true){
            Console.WriteLine("Write To Text File? Y/N");
            choice3 = Console.ReadLine().ToUpper();
            if (choice3 != ""){
                choice = Convert.ToChar(choice3);
                if (char.IsLetter(choice) == true){
                        break;
                    }
            else{Console.Clear();}
           }
       }

       if (choice3 == "Y"){
           string fileName = "";
           while(true){
              Console.Clear();
              Console.WriteLine("Enter File Name (No .txt extension)");
              fileName = Console.ReadLine();
              if (fileName != ""){
                   fileName += ".txt";
                   break;
              }
          }
           File.WriteAllText(fileName, encryptedWord);
        Console.WriteLine("Successfully written to text file");
      }


    }
} //End of affineCipherClassEncrypt

class affineCipherClassDecrypt{
    public void affineCipherDecrypt(){
        string text = "";
        Console.WriteLine("----------------");
        Console.WriteLine("1 - Enter Text Manually");
        Console.WriteLine("2 - Input from File");
        Console.WriteLine("----------------");
        string choiceMenu = "";

        while (true){

            choiceMenu = Console.ReadLine();
            if (choiceMenu != ""){
            break;
        }
        }


        switch(choiceMenu){
            case "2":
            string fileName = "";
            while(true){
                Console.Clear();
                //Gets the user file name
                Console.WriteLine("Enter File Name (with .txt extension)");
                fileName = Console.ReadLine();
                if((fileName != "") && (File.Exists(fileName))){
                    break;
                }
                else{
                    Console.WriteLine("Please Enter a Valid Filename");
                }
            }

            //Loads the files contents into a string
            text = File.ReadAllText(fileName).ToUpper();

            text = text.Replace("\n", "");
            text = text.Replace("\r", "");
            break;

            case "1":
            while (true){
                Console.Clear();
                Console.WriteLine("Enter Text to Decrypt");
                text = Console.ReadLine().ToUpper();
                if (text != ""){
                    break;
                }
            }
            break;

            default:
                Console.WriteLine("Error");
            break;

        }


        string decryptedWord = "";
        char[] alphabetList = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
        int[] keyListA = {1,3,5,7,9,11,15,17,19,21,23,25};

        List<string> possibilityListText = new List<string>();
        List<int> possibilityListKeyA = new List<int>();
        List<int> possibilityListKeyB = new List<int>();

        int finalPosX = 0;
        int keyB = 1;
        int count = 0;

        //Calculates the keys
        while (true){
            keyB = 1;
            while(keyB <= 26){
                decryptedWord = "";
                foreach(char x in text){
                    if (char.IsLetter(x) == true){
                        int pos = Array.IndexOf(alphabetList, x);
                        int inverseMod;
                        int temp = keyListA[count];
                        inverseMod = modInverse(temp, 26);
                        int finalPos = inverseMod * (pos - keyB);
                        finalPosX =  (finalPos%26 + 26)%26;
                        decryptedWord += alphabetList[finalPosX];
                    } else{
                        decryptedWord += x;
                    }

                } //end of foreach loop

                possibilityListText.Add(decryptedWord);
                possibilityListKeyA.Add(keyListA[count]);
                possibilityListKeyB.Add(keyB);


                keyB += 1;

            } //End of while2
            if (keyListA[count] != 25){
                count+= 1;
            } else {
                break;
            }

        } //End of while1

        //List now contains the words

        //Loop for displaying all the possibilities
        Console.WriteLine("312 Possibilities:\n");
        Console.WriteLine("Decryptions:\n");


        int checkCount = 0;
        foreach(string entry in possibilityListText){
          Console.WriteLine("{0} \nKEY SHIFT A: {1} B: {2}", entry, possibilityListKeyA[checkCount], possibilityListKeyB[checkCount]);
          Console.WriteLine("");
          checkCount += 1;
        }

        //Clones the list for writing to files later
        List<string> textList1 = new List<string>(possibilityListText);
        List<int> textList2 = new List<int>(possibilityListKeyA);
        List<int> textList3 = new List<int>(possibilityListKeyB);

        //FREQUENCY ANALYSIS
       Console.WriteLine("----------------------------------------------");
       Console.WriteLine("----------------------------------------------");

       Console.WriteLine("Machine is thinking...");
       Console.WriteLine("Your Top Possibilities Based on Frequency Analysis Are:\n");

        //Initiates letter counts
        int eCountR = 0;
        int tCountR = 0;
        int aCountR = 0;
        int total = 0;

        //Lists to hold the data
        List<string> posText = new List<string>();
        List<int> letterCount = new List<int>();

        //Tallies up the frequency of letters and adds to lists
        foreach(string x in possibilityListText){
            eCountR = (x.Split('E').Length - 1);
            tCountR = (x.Split('T').Length - 1);
            aCountR = (x.Split('R').Length - 1);
            int iCountR = (x.Split('I').Length - 1);
            int oCountR = (x.Split('O').Length - 1);
            int nCountR = (x.Split('N').Length - 1);
            int sCountR = (x.Split('S').Length - 1);
            int hCountR = (x.Split('H').Length - 1);
            total = eCountR + tCountR + aCountR + iCountR + oCountR + nCountR + sCountR + hCountR;
            posText.Add(x);
            letterCount.Add(total);
        }

        //Complex bubble sort to sort the orders of the frequencies and the lists
        int tempF = 0;
        int tempA = 0;
        int tempB = 0;
        string temp2F = "";
        for (int write = 0; write < posText.Count; write++){
            for (int sort = 0; sort < posText.Count - 1; sort++){
                if (letterCount[sort] > letterCount[sort + 1]){
                    tempF = letterCount[sort + 1];
                    letterCount[sort + 1] = letterCount[sort];
                    letterCount[sort] = tempF;

                    temp2F = posText[sort + 1];
                    posText[sort + 1] = posText[sort];
                    posText[sort] = temp2F;

                    tempA = possibilityListKeyA[sort + 1];
                    possibilityListKeyA[sort + 1] = possibilityListKeyA[sort];
                    possibilityListKeyA[sort] = tempA;

                    tempB = possibilityListKeyB[sort + 1];
                    possibilityListKeyB[sort + 1] = possibilityListKeyB[sort];
                    possibilityListKeyB[sort] = tempB;
                  }
              }
          }

        //Prints out the top results on frequency
        int q = posText.Count - 1;
        for(int x = 0; x <= 5; x++){
            Console.WriteLine(posText[q]);
            Console.WriteLine("A:{0} B:{1}", possibilityListKeyA[q],possibilityListKeyB[q]);
            Console.WriteLine("");
            q-=1;
        }

        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("----------------------------------------------");

        //Asks whether the user wants to output to a text file
        char choice2 = '\0';
        string choice5 = "";
        while (true){

            Console.WriteLine("Would you like to output to text file? Y/N?");
            choice5 = Console.ReadLine().ToUpper();
            if(choice5 != "" && choice5.Length == 1){
                choice2 = Convert.ToChar(choice5);
                if ((Char.IsLetter(choice2) == true) && ((choice2 == 'Y') || (choice2 == 'N'))){
                    break;
                }
            }
        }

        int s = posText.Count - 1;

        //Adds to a text file
        if (choice2 == 'Y'){
            if(File.Exists(@"Affine Encryption Possibilities.txt")) //Checks if the file exists and if it does then delete it
            {
                File.Delete(@"Affine Encryption Possibilities.txt");
            }

            checkCount = 0;
            foreach(string entry in textList1){
              File.AppendAllText("Affine Encryption Possibilities.txt", entry + "\n" + "A:" + textList2[checkCount]+ " B:"+ textList3[checkCount] + "\n" + "\n");
              checkCount += 1;

            }

            File.AppendAllText("Affine Encryption Possibilities.txt", "Frequency Analysis Recommends:\n \n");

            for(int x = 0; x <= 5; x++){
                File.AppendAllText("Affine Encryption Possibilities.txt", (posText[s] + ' ' + "A: " + possibilityListKeyA[s] + " B: " + possibilityListKeyB[s] + '\n' + '\n'));
                s -= 1;
            }
          Console.WriteLine("Written to file");
        }

        //Asks if the user wants to output to a webpage
        char choiceHTML = '\0';
        string choiceHTML2 = "";
        Console.Clear();
        s = posText.Count - 1;
        while (true){
            Console.WriteLine("Would you like to output to a Webpage? Y/N?");
            choiceHTML2 = Console.ReadLine().ToUpper();
            if(choiceHTML2 != ""){
                choiceHTML = Convert.ToChar(choiceHTML2);
                if ((Char.IsLetter(choiceHTML) == true) && ((choiceHTML == 'Y') || (choiceHTML == 'N'))){
                    break;
                }
            }
        }

        //Exports to HTML page
        if (choiceHTML == 'Y'){
            if(File.Exists(@"Affine Encryption Possibilities Webpage.html"))
            {
                File.Delete(@"Affine Encryption Possibilities Webpage.html");
            }
            checkCount = 0;
            foreach(string entry in textList1){
              File.AppendAllText("Affine Encryption Possibilities Webpage.html", entry + "<br>" + "A:" + textList2[checkCount]+ " B:"+ textList3[checkCount] + "<br>" + "<br>");
              checkCount += 1;

            }

            File.AppendAllText("Affine Encryption Possibilities Webpage.html", "Frequency Analysis Recommends:<br> <br>");
            for(int x = 0; x <= 5; x++){
                File.AppendAllText("Affine Encryption Possibilities Webpage.html", posText[s] + ' ' + "A:" + possibilityListKeyA[s] + " B:" + possibilityListKeyB[s] + "<br>" + "<br>");
                s -= 1;
            }
          Console.WriteLine("Written to Webpage");
        }
    } //End of affineCipherDecrypt method
    //Method for caulcating the inverse modualr of numbers (required for decryption)
    public static int modInverse(int a, int n){
            int i = n, v = 0, d = 1;
            while (a > 0)
            {
                int t = i / a, x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n;
                return v;
        }//End of modInverse function
} //End of affineCipherClassDecrypt
