using System.Collections.Generic;
using System;

namespace Examen3EV_NS
{
    /// <summary>
    /// Clase para calcular las notas y la media de un alumno
    /// </summary>
    public class ADSG2021_EstadisticasNotas  // esta clase nos calcula las estadísticas de un conjunto de notas 
    {
        /// <summary>
        /// Campo que indica el numero de suspensos
        /// </summary>
        /// <remarks>El tipo es un int</remarks>
        private int suspensos;  // Suspensos
        /// <summary>
        /// Campo que indica el numero de aprobados
        /// </summary>
        /// /// <remarks>El tipo es un int</remarks>
        private int aprobados;  // Aprobados
        /// <summary>
        /// campo que indica el numero de notables
        /// </summary>
        /// /// <remarks>El tipo es un int</remarks>
        private int notables;  // Notables
        /// <summary>
        /// campo que indica el numero de sobresalientes
        /// </summary>
        /// /// <remarks>El tipo es un int</remarks>
        private int sobresalientes;  // Sobresalientes
        /// <summary>
        /// campo que indica la nota media
        /// </summary>
        /// /// <remarks>El tipo es un double</remarks>
        public double media; // Nota media

        /// <summary>
        /// Constantes para los mensajes de las excepciones
        /// </summary>
        public const string ListaVaciaMessage = "La lista no tiene valores";
        public const string ValoresErroneosMessage = "Valores no validos";


        /// <summary>
        /// <para>Propiedad que nos devuelve los suspensos</para>
        /// </summary>
        public int Suspensos 
        {
            get { return suspensos; }
            set { suspensos = value; } 
        }
        /// <summary>
        /// <para>Propiedad que nos devuelve los aprobados</para>
        /// </summary>
        public int Aprobados 
        {
            get { return aprobados; }
            set { aprobados = value; } 
        }
        /// <summary>
        /// <para>Propiedad que nos devuelve los Notables</para>
        /// </summary>
        public int Notables 
        {
            get { return notables; } 
            set { notables = value; } 
        }
        /// <summary>
        /// <para>Propiedad que nos devuelve los sobresalientes</para>
        /// </summary>
        public int Sobresalientes 
        {
            get { return sobresalientes; }
            set { sobresalientes = value; } 
        }
        /// <summary>
        /// <para>Propiedad que nos devuelve la media</para>
        /// </summary>
        public double Media 
        {
            get { return media; }
            set { media = value; } 
        }

        /// <summary>
        /// Constructor en el cual se asignan valores por defecto a los campos
        /// </summary>
        /// <remarks>Los valores por defectos es 0 de todos los campos</remarks>
        public ADSG2021_EstadisticasNotas()
        {
            this.suspensos = 0;
            this.aprobados = 0;
            this.notables = 0;
            this.sobresalientes = 0;  // inicializamos las variables
            this.media = 0;
        }

        /// <summary>
        /// <para>Constructor en el cual pasamos el metodo CalcularEstadisticas y calculamos los valores d elas notas y la media</para>
        /// </summary>
        /// <param name="listaNotas">Una lista de valores para introducir las notas</param>
        /// <remarks>Si los valotres no son validos, el metodo manjea ya esas excepciones</remarks>
        // Constructor a partir de un array, calcula las estadísticas al crear el objeto
        public ADSG2021_EstadisticasNotas(List<int> listaNotas)
        {
            CalcularEstadisticas(listaNotas);
        }



        // Para un conjunto de listnot, calculamos las estadísticas
        // calcula la media y el número de suspensos/aprobados/notables/sobresalientes
        //
        // El método devuelve -1 si ha habido algún problema, la media en caso contrario
        
        /// <summary>
        /// Metodo para calcular estadisticas de la media y de cuantos suspensos,aprobados,notables y sobresalientes tienes
        /// </summary>
        /// <param name="listaNotas">Lista que acepta valores de tipo int</param>
        /// <returns>Devuelve la media de todas las notas en la lista</returns>
        /// <remarks>Las estadisticas de los suspensos, aprobados, notables y sobressalientes e van sumando en los campos</remarks>
        public double CalcularEstadisticas(List<int> listaNotas)
        {                                 
            this.media = 0;

            // TODO: hay que modificar el tratamiento de errores para generar excepciones
            //
            if (listaNotas.Count <= 0)
            {
                throw new Exception("Lista Vacia"); // Si la lista no contiene elementos, devolvemos un error
            }  
                

            for (int i=0; i < listaNotas.Count; i++)
            {
                if (listaNotas[i] < 0 || listaNotas[i] > 10)
                {
                    throw new ArgumentOutOfRangeException("Valores", ValoresErroneosMessage); // comprobamos que las not están entre 0 y 10 (mínimo y máximo), si no, error
                }
                    
            }

                

            for (int i = 0; i < listaNotas.Count; i++)
            {
                if (listaNotas[i] < 5)
                {
                    this.suspensos++;              // Por debajo de 5 suspenso
                }
                else if (listaNotas[i] >= 5 && listaNotas[i] < 7)
                {
                   this.aprobados++;// Nota para aprobar: 5
                }                    
                else if (listaNotas[i] >= 7 && listaNotas[i] < 9)
                {
                    this.notables++;// Nota para notable: 7
                }                    
                else if (listaNotas[i] >= 9)
                {
                    this.sobresalientes++;         // Nota para sobresaliente: 9
                }

                this.media = this.media + listaNotas[i];
            }

            this.media = this.media / listaNotas.Count;

            return this.media;
        }
    }
}
