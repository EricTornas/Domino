namespace DominoEngine{
    
    public class Grafico<T>  where T : IComparable{ 
        public static void ImprimirLasFichasDeTodosLosJugadores(List<IPlayer<T>> players){
            foreach(var jugador in players){
                ImprimirLasFichasDeCadaJugador(jugador.Hand); 
            }
        } 
        public static void ImprimirLasFichasDeCadaJugador(List<IFicha<T>> mano){ // Imprime todas las fichas en la mano
        for(var i = 0; i < mano.Count; i++){
            System.Console.Write($"[{String.Join(",", mano[i].Valores)}]");
        }
        System.Console.WriteLine();
        }
        public static void OrganizarFichasEnELTablero(List<IFicha<T>> piezas_en_el_tablero, IFicha<T> ficha){
            if(piezas_en_el_tablero.Count == 0){
                piezas_en_el_tablero.Add(ficha);
                return;
            }
            
            //System.Console.WriteLine($"Esta es la utima ficha [{String.Join(",",piezas_en_el_tablero.Last().Valores)}]");
            //System.Console.WriteLine($"Esta es la primera ficha [{String.Join(",",piezas_en_el_tablero.First().Valores)}]");
            
            //Es verdadero entonces la ficha machea aqui ahora hay que colocarla
                if(Equals(piezas_en_el_tablero.Last().Valores.Last(),ficha.Valores.First())){
                    //System.Console.WriteLine("Derecha izquierda");
                    List<T> nuevosvalores = new List<T>(); 
                    for(int i = 0; i < ficha.Valores.Count;i++)
                        nuevosvalores.Add(ficha.Valores[i]);
                    IFicha<T> nuevaficha = new Ficha<T>(nuevosvalores);
                    piezas_en_el_tablero.Add(nuevaficha);
                    return;
                }
                else if(Equals(piezas_en_el_tablero.Last().Valores.Last(),ficha.Valores.Last())){ //Hay que voltear la ficha
                //System.Console.WriteLine("Derecha derecha"); //Pendiente a modificar ///Este metodo modifica la lista de valores de la ficha 
                    List<T> nuevosvalores = new List<T>(); //Esto esta mal,buscar un metodo de C# que haga una copia de una lista
                    for(int i = 0; i < ficha.Valores.Count;i++)
                        nuevosvalores.Add(ficha.Valores[ficha.Valores.Count - (1+i)]);
                    IFicha<T> nuevaficha = new Ficha<T>(nuevosvalores);
                    piezas_en_el_tablero.Add(nuevaficha);
                    return;
                }
            
            
                if(Equals(piezas_en_el_tablero.First().Valores.First(),ficha.Valores.Last())){
                    List<T> nuevosvalores = new List<T>(); //Esto esta mal,buscar un metodo de C# que haga una copia de una lista
                    for(int i = 0; i < ficha.Valores.Count;i++)
                        nuevosvalores.Add(ficha.Valores[i]);
                    IFicha<T> nuevaficha = new Ficha<T>(nuevosvalores);
                    List<IFicha<T>> auxiliar = new List<IFicha<T>>();
                    auxiliar.Add(nuevaficha);
                    
                    for(int i = 0; i < piezas_en_el_tablero.Count; i++){
                        auxiliar.Add(piezas_en_el_tablero[i]);
                    }
                    piezas_en_el_tablero.Clear();
                    for(int i = 0; i < auxiliar.Count; i++){
                        piezas_en_el_tablero.Add(auxiliar[i]);
                    }
                    /*System.Console.WriteLine("Imprimiendo fichas auxiliares");
                    Grafico<T>.ImprimirLasFichasDeCadaJugador(auxiliar);
                    System.Console.WriteLine("izquierda derecha");
                    */
                    return;
                    
                }
                else{
                    List<T> nuevosvalores = new List<T>();
                    for(int i = 0; i < ficha.Valores.Count;i++)
                        nuevosvalores.Add(ficha.Valores[ficha.Valores.Count - (1+i)]);
                    IFicha<T> nuevaficha = new Ficha<T>(nuevosvalores);
                    List<IFicha<T>> auxiliar = new List<IFicha<T>>();
                    auxiliar.Add(nuevaficha);
                    
                    for(int i = 0; i < piezas_en_el_tablero.Count; i++){
                        auxiliar.Add(piezas_en_el_tablero[i]);
                    }
                    piezas_en_el_tablero.Clear();
                    for(int i = 0; i < auxiliar.Count; i++){
                        piezas_en_el_tablero.Add(auxiliar[i]);
                    }
                    /*System.Console.WriteLine("Imprimiendo fichas auxiliares");
                    Grafico<T>.ImprimirLasFichasDeCadaJugador(auxiliar);
                    System.Console.WriteLine("izquierda derecha");
                    */
                    return;
                }
                    
                
            
            throw new Exception("Hay un problema al colocar la ficha ");
        }
        public static void ImprimirFichasEnElTablero(List<IFicha<T>> piezas_en_el_tablero){
            ImprimirLasFichasDeCadaJugador(piezas_en_el_tablero);
        }
          
    }
}