/*static void Main(string[] args)
        {   public static List<IPlayer<int>> Seleccion_de_Jugadores(int cantidad_de_jugadores)
    { //Confecciona una lista de jugadores 
        IStrategy<int> fact_player = new Fat_Player<int>();
        IStrategy<int> random_player = new Random_Player<int>();
        IStrategy<int> standart_player = new Standart_Player<int>();
        List<IPlayer<int>> Lista_de_jugadores = new List<IPlayer<int>>();
        System.Console.WriteLine("Configuracion de jugadores:");
        for (int i = 0; i < cantidad_de_jugadores; i++)
        {
            System.Console.WriteLine($"Escriba el nombre del jugador no.{i + 1}");
            string name = Console.ReadLine();
            System.Console.WriteLine($"Selecione el tipo de jugador que es {name} :");
            System.Console.WriteLine("1.Botagorda");
            System.Console.WriteLine("2.Aleatorio");
            System.Console.WriteLine("3.Jugador promedio");
            int tipo_de_jugador = int.Parse(Console.ReadLine());
            if (tipo_de_jugador == 1)
            {
                Lista_de_jugadores.Add(new Player<int>(name, fact_player));
                System.Console.WriteLine($"Jugador no.{i + 1} {name} es de tipo Botagorda");
            }
            else if (tipo_de_jugador == 2)
            {
                Lista_de_jugadores.Add(new Player<int>(name, random_player));
                System.Console.WriteLine($"Jugador no.{i + 1} {name} es de tipo Aleatorio");
            }
            else
            {
                Lista_de_jugadores.Add(new Player<int>(name, standart_player));
                if (tipo_de_jugador != 3) System.Console.WriteLine($"Jugador no.{i + 1} {name} es de tipo por defecto: es de tipo promedio");
                else Console.WriteLine($"Jugador no.{i + 1} {name} es de tipo promedio");
            }
            Console.WriteLine();
            Console.WriteLine( );
        }
        System.Console.WriteLine();
        System.Console.WriteLine();
        return Lista_de_jugadores;
    }

    static void Main(string[] args)
        {
            #region modalidad de juego
            Console.Clear();
            System.Console.WriteLine("Que tipo de juego desea jugar?");
            System.Console.WriteLine("1.Clasico doble 9");
            System.Console.WriteLine("2.Clasico doble 6");
            System.Console.WriteLine("3.Longaniza");
            System.Console.WriteLine("4.Primo doble 6");
            int modalidad_de_juego = int.Parse(Console.ReadLine()); //Recibe el modo de juego
            IGameMode<int> tipo_de_juego = null;
            IGenerator<int> tipo_de_estuche = null;
            IDistribution<int> tipo_de_distribucion = null;
            if (modalidad_de_juego == 1)
            { //Doble 9
                int[] Cuantas9 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                tipo_de_juego = new ClassicGame<int>();
                tipo_de_estuche = new ClassicGenerator<int>(Cuantas9);
                tipo_de_distribucion = new ClassicDistribution<int>();
                System.Console.WriteLine("Se eligio el juego : Doble 9 Clasico");
            }
            else if (modalidad_de_juego == 2)
            { //Doble 6
                int[] Cuantas6 = { 0, 1, 2, 3, 4, 5, 6 };
                tipo_de_juego = new ClassicGame<int>();
                tipo_de_estuche = new ClassicGenerator<int>(Cuantas6);
                tipo_de_distribucion = new ClassicDistribution<int>();
                System.Console.WriteLine("Se eligio el juego : Doble 6 Clasico");
            }
            else if (modalidad_de_juego == 3)
            { //Longaniza
                int[] Cuantas9 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                tipo_de_juego = new LonganizaGame<int>();
                tipo_de_estuche = new ClassicGenerator<int>(Cuantas9);
                tipo_de_distribucion = new ClassicDistribution<int>();
                System.Console.WriteLine("Se eligio el juego : Longaniza");
            }
            else
            { //En su defecto doble 9
                int[] Cuantas6 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                tipo_de_juego = new ClassicGame<int>();
                tipo_de_estuche = new ClassicGenerator<int>(Cuantas6);
                tipo_de_distribucion = new ClassicDistribution<int>();
                System.Console.WriteLine("Se eligio el juego por defecto: Doble 9 Clasico");
            }
            System.Console.WriteLine("Precione el boton enter para continuar");
            System.Console.ReadLine();
            #endregion
            #region puntuacion de la ficha 
            Console.Clear();
            System.Console.WriteLine("Como desea que se puntue las fichas en el marcador?");
            System.Console.WriteLine("1.De la manera tradicional");
            System.Console.WriteLine("2.puntuando solo las fichas dobles");
            int respuesta = int.Parse(Console.ReadLine());
            IScore<int> modo_de_puntuar_las_fichas = null;
            if (respuesta == 1)
            {
                modo_de_puntuar_las_fichas = new ClassicScore<int>();
                System.Console.WriteLine("Se eligio la manera tradicional");
            }
            else if (respuesta == 2)
            {
                modo_de_puntuar_las_fichas = new DoubleScore<int>();
                System.Console.WriteLine("Se eligio solo puntuar las dobles");
            }
            else
            {
                modo_de_puntuar_las_fichas = new ClassicScore<int>();
                System.Console.WriteLine("Se eligio la opcion por defecto :la manera tradicional");
            }
            System.Console.WriteLine("Precione el boton enter para continuar");
            Console.ReadLine();
            #endregion

            #region equipos
            Console.Clear();
            System.Console.WriteLine("Con cuantos jugadores desea jugar?: ");
            int total_de_jugadores = int.Parse(Console.ReadLine()); // Recibe la cantidad de jugadores
      

            ICouple<int> parejas = null;
            if (total_de_jugadores <= 1 || total_de_jugadores > 4)
            { // Se eligio una cantidad 
                total_de_jugadores = 2;
                System.Console.WriteLine("Se escogio la cantidad de jugadores por defecto. Cant de jugadores : {0} ", 2);
                System.Console.WriteLine();
                parejas = new Couples<int>(1);
            }
            else if (total_de_jugadores > 2 && total_de_jugadores % 2 == 0)
            {
                System.Console.WriteLine("Desea jugar en equipo: Si - No");
                string resp = Console.ReadLine();
                if (resp.ToLower() == "si") parejas = new Couples<int>(2); //Dos parejas de dos jugadores
                else parejas = new Couples<int>(1); //Sin parejas 
            }
            else parejas = new Couples<int>(1);//Solo hay tres jugadores 
            List<IPlayer<int>> lista_de_jugadores = new List<IPlayer<int>>();
            lista_de_jugadores = Seleccion_de_Jugadores(total_de_jugadores); //Se configura los jugadores
            parejas.Team(lista_de_jugadores);
            #endregion
            #region Se conforma las reglas del juego y el referee con la informacion recibida anteriormente 
            IRules<int> reglas_del_juego = new Rules<int>(tipo_de_juego, tipo_de_estuche, tipo_de_distribucion, modo_de_puntuar_las_fichas, parejas, 10);
            IReferee<int> arbitro = new Referee<int>(lista_de_jugadores, parejas.Teams_in_Smash); //el arbitro recibe los jugadores y las parejas 
            #endregion
            #region condicion de victoria
            IDomino<int> Domino = null;
            System.Console.WriteLine("Qué modo desea jugar ? ");
            System.Console.WriteLine("1. Amistoso");
            System.Console.WriteLine("2. Por puntos");
            System.Console.WriteLine("3. Por cantidad de rondas ");
            int domino_por = int.Parse(Console.ReadLine());
            if (domino_por == 1)
            {
                Domino = (IDomino<int>)new Domino_for_Rounds<int>(reglas_del_juego, arbitro, lista_de_jugadores, 1); /// 
            }
            else if (respuesta == 2)
            {
                System.Console.WriteLine("Hasta cuantos puntos desea jugar ?");
                int puntuacion_maxima = int.Parse(Console.ReadLine());
                if (puntuacion_maxima > 0) Domino = (IDomino<int>)new Domino_for_Point<int>(reglas_del_juego, arbitro, lista_de_jugadores, puntuacion_maxima);
                else
                {
                    Domino = (IDomino<int>)new Domino_for_Point<int>(reglas_del_juego, arbitro, lista_de_jugadores, 100); //
                    System.Console.WriteLine("Se escogio la cantidad de puntos a terminar por defecto. Cantidad de puntos a terminar : {0}", 100);
                    System.Console.WriteLine();
                }
            }
            else if (respuesta == 3)
            {
                System.Console.WriteLine("Cuantos partidos deciden la victoria?");
                int cantidad_de_rondas = int.Parse(Console.ReadLine());
                if (cantidad_de_rondas > 0) Domino = (IDomino<int>)new Domino_for_Rounds<int>(reglas_del_juego, arbitro, lista_de_jugadores, cantidad_de_rondas);
                else
                {
                    Domino = (IDomino<int>)new Domino_for_Rounds<int>(reglas_del_juego, arbitro, lista_de_jugadores, 1);
                    System.Console.WriteLine($"Se eligio la cantidad por defecto {1}");
                }
            }
        Domino.Play();
            #endregion
            #region Graficacion del juego
            #endregion
        }
            //doble nueve
            int[] Cuantas9 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //doble sies 
            int[] Cuantas6 = { 0, 1, 2, 3, 4, 5, 6 };
            //numeros primos
            int[] NumerosPrimos_doble6 = { 2, 3, 5, 7, 11, 13, 17 };


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
            Domino_for_Rounds<int> domino_rounds = new Domino_for_Rounds<int>(rules, referee, players, 3);
            Domino_for_Point<int> domino_score = new Domino_for_Point<int>(rules, referee, players, 5);
            //table.Start();
            //domino_rounds.Play();
            //domino_score.Play();
            for (var i = 0; i < 3; i++){
                table.Start();
                table.Resert();
            }
            IRules<int> rules_longaniza = new Rules<int>(longaniza_game, classic_generator, classic_distribution, classic_score, couple, 10);
            Table<int> table_longaniza = new Table<int>(rules_longaniza,referee,players);
            table_longaniza.Start();
            Ficha<int> ficha_de_prueba = new Ficha<int>(new List<int>(){1,2});
            int comp = ficha_de_prueba.Valores.First();
            int flag = 0;
                foreach (var value in ficha_de_prueba.Valores)
                    if(!Equals(comp,value)) {
                        System.Console.WriteLine("F"); flag = 1;break;}
                if(flag==0) System.Console.WriteLine("T");
        }
        */

        /*public static List<IPlayer<int>> Seleccion_de_Jugadores(int cantidad_de_jugadores){ //Confecciona una lista de jugadores 
            IStrategy<int> fact_player = new Fat_Player<int>();
            IStrategy<int> random_player = new Random_Player<int>();
            IStrategy<int> standart_player = new Standart_Player<int>();
            List<IPlayer<int>> Lista_de_jugadores = new List<IPlayer<int>>();
            System.Console.WriteLine("Configuracion de jugadores:");
            for(int i = 0; i < cantidad_de_jugadores;i++){
                System.Console.WriteLine($"Escriba el nombre del jugador no.{i+1}");
                string name = Console.ReadLine();
                System.Console.WriteLine($"Selecione el tipo de jugador que es {name} :");
                System.Console.WriteLine("1.Botagorda");
                System.Console.WriteLine("2.Aleatorio");
                System.Console.WriteLine("3.Jugador promedio");
                int tipo_de_jugador = int.Parse(Console.ReadLine());
                if(tipo_de_jugador ==1){
                    Lista_de_jugadores.Add(new Player<int>(name,fact_player));
                    System.Console.WriteLine($"Jugador no.{i+1} {name} es de tipo Botagorda");
                }
                else if(tipo_de_jugador ==2){
                    Lista_de_jugadores.Add(new Player<int>(name,random_player));
                    System.Console.WriteLine($"Jugador no.{i+1} {name} es de tipo Aleatorio");
                }
                else {
                    Lista_de_jugadores.Add(new Player<int>(name,standart_player));
                    if(tipo_de_jugador!=3)System.Console.WriteLine($"Jugador no.{i+1} {name} es de tipo por defecto: es de tipo promedio");
                    else Console.WriteLine($"Jugador no.{i+1} {name} es de tipo promedio");
                }
            }
            System.Console.WriteLine();
            System.Console.WriteLine();
            return Lista_de_jugadores;
        }
        
        static void Main(string[] args){
            #region modalidad de juego
            Console.Clear();
            System.Console.WriteLine("Que tipo de juego desea jugar?");
            System.Console.WriteLine("1.Clasico doble 9");
            System.Console.WriteLine("2.Clasico doble 6");
            System.Console.WriteLine("3.Longaniza");
            System.Console.WriteLine("4.Primo doble 6");
            int modalidad_de_juego = int.Parse(Console.ReadLine()); //Recibe el modo de juego
            IGameMode<int> tipo_de_juego = null;
            IGenerator<int> tipo_de_estuche = null;
            IDistribution<int> tipo_de_distribucion = null;
            if(modalidad_de_juego ==1){ //Doble 9
                int[] Cuantas9 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                tipo_de_juego = new ClassicGame<int>();
                tipo_de_estuche = new ClassicGenerator<int>(Cuantas9);
                tipo_de_distribucion = new ClassicDistribution<int>();
                System.Console.WriteLine("Se eligio el juego : Doble 9 Clasico");
            }
            else if(modalidad_de_juego ==2){ //Doble 6
                int[] Cuantas6 = { 0, 1, 2, 3, 4, 5, 6};
                tipo_de_juego = new ClassicGame<int>();
                tipo_de_estuche = new ClassicGenerator<int>(Cuantas6);
                tipo_de_distribucion = new ClassicDistribution<int>();
                System.Console.WriteLine("Se eligio el juego : Doble 6 Clasico");
            }
            else if(modalidad_de_juego ==3){ //Longaniza
                int[] Cuantas9 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                tipo_de_juego = new LonganizaGame<int>();
                tipo_de_estuche = new ClassicGenerator<int>(Cuantas9);
                tipo_de_distribucion = new ClassicDistribution<int>();
                System.Console.WriteLine("Se eligio el juego : Longaniza");
            }
            else{ //En su defecto doble 9
                int[] Cuantas6 = { 0, 1, 2, 3, 4, 5, 6,7,8,9};
                tipo_de_juego = new ClassicGame<int>();
                tipo_de_estuche = new ClassicGenerator<int>(Cuantas6);
                tipo_de_distribucion = new ClassicDistribution<int>();
                System.Console.WriteLine("Se eligio el juego por defecto: Doble 9 Clasico");
            }
            System.Console.WriteLine("Precione el boton enter para continuar");
            System.Console.ReadLine();
        #endregion 
        #region puntuacion de la ficha 
            Console.Clear();
            System.Console.WriteLine("Como desea que se puntue las fichas en el marcador?");
            System.Console.WriteLine("1.De la manera tradicional");
            System.Console.WriteLine("2.puntuando solo las fichas dobles");
            int respuesta = int.Parse(Console.ReadLine());
            IScore<int> modo_de_puntuar_las_fichas = null;
            if(respuesta == 1){
                modo_de_puntuar_las_fichas = new ClassicScore<int>();
                System.Console.WriteLine("Se eligio la manera tradicional");
            }
            else if(respuesta == 2){
                modo_de_puntuar_las_fichas = new DoubleScore<int>();
                System.Console.WriteLine("Se eligio solo puntuar las dobles");
            }
            else{
                modo_de_puntuar_las_fichas = new ClassicScore<int>();
                System.Console.WriteLine("Se eligio la opcion por defecto :la manera tradicional");
            }
            System.Console.WriteLine("Precione el boton enter para continuar");
            Console.ReadLine();
        #endregion
        
        #region equipos
            Console.Clear();
            System.Console.WriteLine("Con cuantos jugadores desea jugar?: ");
            int total_de_jugadores = int.Parse(Console.ReadLine()); // Recibe la cantidad de jugadores
            bool equipo_si = false;
            
            ICouple<int> parejas = null;
            if(total_de_jugadores <= 1 || total_de_jugadores > 4){ // Se eligio una cantidad 
                total_de_jugadores = 2;
                System.Console.WriteLine("Se escogio la cantidad de jugadores por defecto. Cant de jugadores : {0} ", 2);
                System.Console.WriteLine();
                parejas = new Couples<int>(1);
            }
            else if (total_de_jugadores > 2 && total_de_jugadores % 2 == 0){
                System.Console.WriteLine("Desea jugar en equipo: Si - No");
                string resp = Console.ReadLine();
            if (resp.ToLower() == "si") parejas = new Couples<int>(2); //Dos parejas de dos jugadores
            else parejas = new Couples<int>(1); //Sin parejas 
            }
            else parejas = new Couples<int>(1);//Solo hay tres jugadores 
            List<IPlayer<int>> lista_de_jugadores = new List<IPlayer<int>>();
            lista_de_jugadores = Seleccion_de_Jugadores(total_de_jugadores); //Se configura los jugadores
            parejas.Team(lista_de_jugadores);
        #endregion
        #region Se conforma las reglas del juego y el referee con la informacion recibida anteriormente 
        IRules<int> reglas_del_juego = new Rules<int>(tipo_de_juego,tipo_de_estuche,tipo_de_distribucion,modo_de_puntuar_las_fichas,parejas,10);
        IReferee<int> arbitro = new Referee<int>(lista_de_jugadores,parejas.Teams_in_Smash); //el arbitro recibe los jugadores y las parejas 
        #endregion
        #region condicion de victoria
            IDomino<int> Domino = null;
            System.Console.WriteLine("Qué modo desea jugar ? ");
            System.Console.WriteLine("1. Amistoso");
            System.Console.WriteLine("2. Por puntos");
            System.Console.WriteLine("3. Por cantidad de rondas ");
            int domino_por = int.Parse(Console.ReadLine());
            if(domino_por == 1){
                Domino = (IDomino<int>)new Domino_for_Rounds<int>(reglas_del_juego,arbitro,lista_de_jugadores,1); /// 
            }
            else if (respuesta == 2){
                System.Console.WriteLine("Hasta cuantos puntos desea jugar ?");
                int puntuacion_maxima = int.Parse(Console.ReadLine());
                if (puntuacion_maxima > 0) Domino = (IDomino<int>)new Domino_for_Point<int>(reglas_del_juego,arbitro,lista_de_jugadores,puntuacion_maxima);
                else{
                    Domino = (IDomino<int>)new Domino_for_Point<int>(reglas_del_juego,arbitro,lista_de_jugadores,100); //
                    System.Console.WriteLine("Se escogio la cantidad de puntos a terminar por defecto. Cantidad de puntos a terminar : {0}", 100);
                    System.Console.WriteLine();
                }
            }
            else if (respuesta == 3){
            System.Console.WriteLine("Cuantos partidos deciden la victoria?");
            int cantidad_de_rondas = int.Parse(Console.ReadLine());
            if (cantidad_de_rondas > 0) Domino = (IDomino<int>)new Domino_for_Rounds<int>(reglas_del_juego,arbitro,lista_de_jugadores,cantidad_de_rondas);
            else {
                Domino = (IDomino<int>)new Domino_for_Rounds<int>(reglas_del_juego,arbitro,lista_de_jugadores,1);
                System.Console.WriteLine($"Se eligio la cantidad por defecto {1}");
            }
            }
    #endregion
        #region Graficacion del juego
        #endregion
    }*/