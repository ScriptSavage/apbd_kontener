﻿namespace APBD_Kontenery.Classes;

public class Ship
{
    public Ship(int maxSpeed, int maxcapacity, int maxLoadWeight) {
            _maxCapacity = maxcapacity;
            _maxLoadWeight = maxLoadWeight;
            _maxSpeed = maxSpeed;
        }
     
        public void LoadBoat(Container container) {
            if (_capacity >= _maxCapacity)
            {
                throw new OverFillException("Za duza ladownosc");
            }
            if (_loadweight + container.CargoWeight > _maxLoadWeight) {
                throw new OverFillException("Za duza waga kontenra");
            }

            _containers[container.SerialNumber] = container;
            _capacity++;
            _loadweight += (int)container.CargoWeight;
        }
        public void LoadBoat(List<Container> containers) {
            if (_capacity + containers.Count > _maxCapacity)   throw new OverFillException("Za ma miejsca na kontenery");
            int sum = 0;
            foreach (Container item in containers) {
               sum += (int)item.CargoWeight;
            }
            if (_loadweight + sum > _maxLoadWeight)  throw new OverFillException("Kontenry sa za ciezkie");
            foreach (var item in containers) {
                LoadBoat(item);
            }
        }
        public void DestroyContainer(string serialNumber) {
            if (_containers.ContainsKey(serialNumber)) {
                _capacity--;
                _loadweight -= (int)_containers[serialNumber].CargoWeight;
                _containers.Remove(serialNumber);
            }
            else {
                throw new ArgumentException("Nie znaleziono kontenera");
            }
        }
        public Container DeLoadContainer(string serialNumber) {
            if (_containers.ContainsKey(serialNumber)) {
                Container container = _containers[serialNumber];
                _capacity--;
                _loadweight -= (int)container.CargoWeight;
                _containers.Remove(serialNumber);
                return container;
            }
            else {
                throw new ArgumentException("Nie znaleziono kontenera");
            }
        }
        public void ReplaceContainer(string oldSerialNumber, Container newContainer) {
            if (_containers.ContainsKey(oldSerialNumber)) {
                _loadweight -= (int)_containers[oldSerialNumber].CargoWeight;
                _loadweight += (int)newContainer.CargoWeight;
                _containers.Remove(oldSerialNumber);
                _containers[newContainer.SerialNumber] = newContainer;
            }
            else {
                throw new ArgumentException("Nie znaleziono kontenera");
            }
        }
        public string DescribeBoat() {
            return (_capacity + _loadweight/_maxLoadWeight + _maxSpeed).ToString();
        }
        public static void ChangeContainter(Ship from, Ship to, string serialNumber) {
            Container container = from.DeLoadContainer(serialNumber);
            to.LoadBoat(container);
        }
        private Dictionary<string, Container> _containers = new Dictionary<string, Container>();
        private int _capacity = 0;
        private int _maxCapacity;
        private int _loadweight = 0;
        private int _maxLoadWeight;
        private int _maxSpeed;
    }