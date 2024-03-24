namespace APBD_Kontenery.Classes;

public class Ship
{
    
 private Ship(int maxSpeed, int maxcapacity, int maxLoadWeight) {
            _maxCapacity = maxcapacity;
            _maxLoadWeight = maxLoadWeight;
            _maxSpeed = maxSpeed;
        }
        public static Ship Create(int maxSpeed, int maxcapacity, int maxLoadWeight){
            return new Ship(maxSpeed,maxcapacity,maxLoadWeight);
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
          //  _loadweight += container.MaximumLoad;
        }
        public void LoadBoat(List<Container> containers) {
            if (_capacity + containers.Count > _maxCapacity)   throw new OverFillException("Za ma miejsca na kontenery");
            int sum = 0;
            foreach (Container item in containers) {
             //   sum += item.CargoWeight;
            }
            if (_loadweight + sum > _maxLoadWeight)  throw new OverFillException("Kontenry sa za ciezkie");
            foreach (var item in containers) {
                LoadBoat(item);
            }
        }
        public void DestroyContainer(string serialNumber) {
            if (_containers.ContainsKey(serialNumber)) {
                _capacity--;
             //   _loadweight -= _containers[serialNumber].Mass;
                _containers.Remove(serialNumber);
            }
            else {
                throw new ArgumentException("No container found with the specified serial number.");
            }
        }
        public Container DeLoadContainer(string serialNumber) {
            if (_containers.ContainsKey(serialNumber)) {
                Container container = _containers[serialNumber];
                _capacity--;
             //   _loadweight -= container.Mass;
                _containers.Remove(serialNumber);
                return container;
            }
            else {
                throw new ArgumentException("No container found with the specified serial number.");
            }
        }
        public void ReplaceContainer(string oldSerialNumber, Container newContainer) {
            if (_containers.ContainsKey(oldSerialNumber)) {
           //     _loadweight -= _containers[oldSerialNumber].Mass;
               // _loadweight += newContainer.CargoWeight;
                _containers.Remove(oldSerialNumber);
                _containers[newContainer.SerialNumber] = newContainer;
            }
            else {
                throw new ArgumentException("No container found with the specified serial number.");
            }
        }
        public string DescribeBoat() {
            String toRet ="";
            toRet.Concat($"{GetType().Name}: Capacity - {_capacity}/{_maxCapacity}, Total Mass - {_loadweight}/{_maxLoadWeight}, Max Speed - {_maxSpeed}");
            toRet.Concat("Containers:");
            return toRet;
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