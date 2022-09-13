
namespace DominoEngine
{
    public class Program
    {
        static void Main(string[] args)
        {   
            //doble nueve
            int[] Cuantas9 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //doble sies 
            int[] Cuantas6 = { 0, 1, 2, 3, 4, 5, 6 };
            //numeros primos
            int[] NumerosPrimos_doble6 = { 2, 3, 5, 7, 11, 13, 17 };
            int a = 1;
            System.Console.WriteLine(Equals(1,a));
            IScore<int> classic_score = new ClassicScore<int>();
            IDistribution<int> classic_distribution = new ClassicDistribution<int>();
            IGenerator<int> classic_generator = new ClassicGenerator<int>(Cuantas9);
            IGameMode<int> classic_game = new ClassicGame<int>();
            IGameMode<int> longaniza_game = new LonganizaGame<int>();
            IStrategy<int> fact_player = new Fat_Player<int>();
            IStrategy<int> random_player = new Random_Player<int>();
            IStrategy<int> standart_player = new Standart_Player<int>();


            IPlayer<int> player1 = new Player<int>("Adriana", standart_player);
            IPlayer<int> player2 = new Player<int>("Gilbert", fact_player);
            IPlayer<int> player3 = new Player<int>("Cusco", fact_player);
            IPlayer<int> player4 = new Player<int>("Nubia", random_player);
            List<IPlayer<int>> players = new List<IPlayer<int>>();


            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);

            ICouple<int> couple = new Couples<int>(1);
            couple.Team(players);
            IReferee<int> referee = new Referee<int>(players, couple.Teams_in_Smash);
            IRules<int> rules = new Rules<int>(classic_game, classic_generator, classic_distribution, classic_score, couple, 10);
            Table<int> table = new Table<int>(rules,referee,players);
            Domino_for_Rounds<int> domino_rounds = new Domino_for_Rounds<int>(rules, referee, players,1);
            Domino_for_Point<int> domino_score = new Domino_for_Point<int>(rules, referee, players, 5);
            //table.Start();
            //foreach(var state in domino_rounds.Play());

            
            //domino_score.Play();
            /*for (var i = 0; i < 1; i++){
                table.Play();
                table.Resert();
            }*/
            IRules<int> rules_longaniza = new Rules<int>(longaniza_game, classic_generator, classic_distribution, classic_score, couple, 10);
            Table<int> table_longaniza = new Table<int>(rules_longaniza,referee,players);
            Domino_for_Rounds<int> domino_longaniza = new Domino_for_Rounds<int>(rules_longaniza,referee,players,1);
            foreach(var state in domino_longaniza.Play());
            /*table_longaniza.Start();
            Ficha<int> ficha_de_prueba = new Ficha<int>(new List<int>(){1,2});
            int comp = ficha_de_prueba.Valores.First();
            int flag = 0;
                foreach (var value in ficha_de_prueba.Valores)
                    if(!Equals(comp,value)) {
                        System.Console.WriteLine("F"); flag = 1;break;}
                if(flag==0) System.Console.WriteLine("T");*/
        }
    }
}