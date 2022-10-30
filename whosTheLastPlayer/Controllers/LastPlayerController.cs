using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace whosTheLastPlayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LastPlayerController : ControllerBase
    {
        public LastPlayerController()
        {
        }

        [HttpPost("{numberOfPlayer}")]
        public int GetLastPlayer(int numberOfPlayer)
        {
            int[] players = new int[numberOfPlayer];
            int currentPlayer;
            int currentStep;
            int numberOfEliminated = 0;
            int numberOfPlayerEndOfTheCircle = 0;

            if (numberOfPlayer == 0)
            {
                return 0;
            }
            else
            {
                for(int i= 0; i< numberOfPlayer; i++)
                {
                    //tüm elemanlar bir arraye toplanır.
                    players[i] = i + 1;
                }
            }

            currentPlayer = players[0];
            Console.WriteLine("CURRENT OYUNCU(BAŞLANGIÇ): " + currentPlayer);
            currentStep = currentPlayer;

            for (int i = currentStep; i <= numberOfPlayer; i++)
            {

                if(numberOfEliminated == numberOfPlayer - 1)
                {
                    Console.WriteLine("GAME OVER3. LAST OYUNCU: " + currentPlayer);
                    break;
                }


                Console.WriteLine("i = " + i);

                //eleme işlemi için sıradaki oyuncudan sonraki ilk elenmemiş oyuncu bulunmalı.
                for (int j = currentStep; j < numberOfPlayer; j++)
                {
                    if (currentPlayer == numberOfPlayer - 1)
                    {
                        //liste sonuna ulaştım! Başa dönmem lazım.
                        i = 0;
                        currentStep = 0;
                        Console.WriteLine("LİSTE SONU");
                    }


                    if (players[j] != 0) //elenmemiş ilk oyuncu bulundu.
                    {
                        players[j] = 0; //elendi.
                        numberOfEliminated++;
                        Console.WriteLine("ELENDİ: " + (j+1));

                        break;
                    }
                }

                for (int k = currentPlayer; k < numberOfPlayer; k++)
                {
                    if (players[k] != 0)
                        numberOfPlayerEndOfTheCircle++;
                }

                if (numberOfPlayerEndOfTheCircle == 0)
                {
                    //liste sonuna ulaştım! Başa dönmem lazım.
                    i = 0;
                    currentStep = 0;
                    Console.WriteLine("LİSTE SONU2");
                }

                numberOfPlayerEndOfTheCircle = 0;



                //sıradaki oyuncu belirlenmeli.
                for (int z = currentStep; z < numberOfPlayer; z++)
                {
                    if(players[z] != 0) //elenmemiş ilk oyuncu bulundu.
                    {
                        currentPlayer = players[z]; // sıradaki oyuncu olarak seçildi.
                        currentStep = currentPlayer;
                        Console.WriteLine("CURRENT OYUNCU: " + currentPlayer);
                        
                        if (currentPlayer == numberOfPlayer)
                        {
                            //liste sonuna ulaştım! Başa dönmem lazım.
                            i = 0;
                            currentStep = 0;
                            Console.WriteLine("LİSTE SONU");
                        }

                        break;
                    }
                }

                for(int k = currentPlayer; k < numberOfPlayer; k++)
                {
                    if (players[k] != 0)
                        numberOfPlayerEndOfTheCircle++;
                }

                if(numberOfPlayerEndOfTheCircle == 0)
                {
                    //liste sonuna ulaştım! Başa dönmem lazım.
                    i = 0;
                    currentStep = 0;
                    Console.WriteLine("LİSTE SONU2");
                }

                numberOfPlayerEndOfTheCircle = 0;

            }

            return currentPlayer;
        }
    }
}
