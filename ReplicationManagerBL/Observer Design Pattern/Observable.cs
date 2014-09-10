using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplicationManagerBL.Observer_Design_Pattern
{
    public abstract class Observable
    {
        private List<Observer> _Observers = new List<Observer>();


        /// <summary>
        /// Agrega un objecto a la ista de observadoresen caso de no estar.
        /// </summary>
        /// <param name="observer">Observador a aggregar</param>
        public void AddObserver(Observer observer)
        {
            if (!_Observers.Contains(observer))
            {
                _Observers.Add(observer);
            }            
        }


        /// <summary>
        /// Remueve un objeto observador de la lista.
        /// </summary>
        /// <param name="observer">Observador a remover</param>
        public void RemoveObserver(Observer observer)
        {
            _Observers.Remove(observer);
        }


        /// <summary>
        /// Método que notifica a todos los observadores.
        /// </summary>
        public void Notify()
        {            
            foreach (Observer observer in _Observers)
            {
                observer.Update();
            }
        }
    }
}
