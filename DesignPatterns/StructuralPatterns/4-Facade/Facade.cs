using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Facade
{
    /*The Facade Design Pattern aims to:

 Simplify interactions: It simplifies the interaction with a complex system by providing a
    single entry point (the Facade) to a set of interfaces in a subsystem.
 Hide complexity: It hides the complexities of the subsystem from the client,
    making the subsystem easier to use.
 Reduce dependencies: It reduces the dependencies of the client code on the internal
    implementation of the subsystem.
 
    Example
 Suppose we have a home theater system with various components like a DVD player,
    a projector, lights, and a sound system.Each component has its own interface and methods.
    Using the Facade Design Pattern,
    we can create a HomeTheaterFacade that simplifies the operation of the home theater system.*/

#region Components of the Home Theater System  
    public class DvdPlayer
    {
        public void On() => Console.WriteLine("DVD Player is on.");
        public void Play(string movie) => Console.WriteLine($"Playing \"{movie}\".");
        public void Stop() => Console.WriteLine("DVD Player stopped.");
        public void Off() => Console.WriteLine("DVD Player is off.");
    }

    public class Projector
    {
        public void On() => Console.WriteLine("Projector is on.");
        public void Off() => Console.WriteLine("Projector is off.");
    }

    public class Lights
    {
        public void Dim(int level) => Console.WriteLine($"Lights are dimmed to {level}%.");
    }

    public class SoundSystem
    {
        public void On() => Console.WriteLine("Sound System is on.");
        public void SetVolume(int level) => Console.WriteLine($"Sound System volume set to {level}.");
        public void Off() => Console.WriteLine("Sound System is off.");
    }
    #endregion


    #region Facade Class
    public class HomeTheaterFacade
    {
        private readonly DvdPlayer _dvdPlayer;
        private readonly Projector _projector;
        private readonly Lights _lights;
        private readonly SoundSystem _soundSystem;

        public HomeTheaterFacade(DvdPlayer dvdPlayer, Projector projector, Lights lights, SoundSystem soundSystem)
        {
            _dvdPlayer = dvdPlayer;
            _projector = projector;
            _lights = lights;
            _soundSystem = soundSystem;
        }

        public void WatchMovie(string movie)
        {
            Console.WriteLine("Get ready to watch a movie...");
            _lights.Dim(10);
            _projector.On();
            _soundSystem.On();
            _soundSystem.SetVolume(5);
            _dvdPlayer.On();
            _dvdPlayer.Play(movie);
        }

        public void EndMovie()
        {
            Console.WriteLine("Shutting movie theater down...");
            _dvdPlayer.Stop();
            _dvdPlayer.Off();
            _soundSystem.Off();
            _projector.Off();
            _lights.Dim(100);
        }
    }

    #endregion

    /*Client Code*/
    public class Program
    {
        public static void Main()
        {
            var dvdPlayer = new DvdPlayer();
            var projector = new Projector();
            var lights = new Lights();
            var soundSystem = new SoundSystem();

            var homeTheater = new HomeTheaterFacade(dvdPlayer, projector, lights, soundSystem);

            homeTheater.WatchMovie("Inception");
            // Movie playing...
            homeTheater.EndMovie();
        }
    }

}
