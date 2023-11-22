#include <iostream>
#include <string>
#include <map>


using namespace std;



enum Type {
    PROTOTYPE_1 = 0,
    PROTOTYPE_2
};

/**
 * The example class that has cloning ability. We'll see how the values of field
 * with different types will be cloned.
 */

class Prototype {
protected:
    string prototype_name_;
    float prototype_field_;

public:
    Prototype() {}
    Prototype(string prototype_name)
        : prototype_name_(prototype_name) {
    }
    virtual ~Prototype() {}
    virtual Prototype* Clone() const = 0;
    virtual void Method(float prototype_field) {
        this->prototype_field_ = prototype_field;
        std::cout << "Call Method from " << prototype_name_ << " with field : " << prototype_field << std::endl;
    }
};

/**
 * ConcretePrototype1 is a Sub-Class of Prototype and implement the Clone Method
 * In this example all data members of Prototype Class are in the Stack. If you
 * have pointers in your properties for ex: String* name_ ,you will need to
 * implement the Copy-Constructor to make sure you have a deep copy from the
 * clone method
 */

class ConcretePrototype1 : public Prototype {
private:
    float concrete_prototype_field1_;

public:
    ConcretePrototype1(string prototype_name, float concrete_prototype_field)
        : Prototype(prototype_name), concrete_prototype_field1_(concrete_prototype_field) {
    }

    /**
     * Notice that Clone method return a Pointer to a new ConcretePrototype1
     * replica. so, the client (who call the clone method) has the responsability
     * to free that memory. I you have smart pointer knowledge you may prefer to
     * use unique_pointer here.
     */
    Prototype* Clone() const override {
        return new ConcretePrototype1(*this);
    }
};

class ConcretePrototype2 : public Prototype {
private:
    float concrete_prototype_field2_;

public:
    ConcretePrototype2(string prototype_name, float concrete_prototype_field)
        : Prototype(prototype_name), concrete_prototype_field2_(concrete_prototype_field) {
    }
    Prototype* Clone() const override {
        return new ConcretePrototype2(*this);
    }
};

/**
 * In PrototypeFactory you have two concrete prototypes, one for each concrete
 * prototype class, so each time you want to create a bullet , you can use the
 * existing ones and clone those.
 */

class PrototypeFactory {
private:
    map<Type, Prototype*> cache;

public:
    PrototypeFactory() {
        cache[Type::PROTOTYPE_1] = new ConcretePrototype1("PROTOTYPE_1 ", 50.f);
        cache[Type::PROTOTYPE_2] = new ConcretePrototype2("PROTOTYPE_2 ", 60.f);
    }

    /**
     * Be carefull of free all memory allocated. Again, if you have smart pointers
     * knowelege will be better to use it here.
     */

    ~PrototypeFactory() {
        delete cache[Type::PROTOTYPE_1];
        delete cache[Type::PROTOTYPE_2];
    }

    /**
     * Notice here that you just need to specify the type of the prototype you
     * want and the method will create from the object with this type.
     */
    Prototype* CreatePrototype(Type type) {
        return cache[type]->Clone();
    }
};

void Client(PrototypeFactory& prototype_factory) {
    std::cout << "Let's create a Prototype 1\n";

    Prototype* prototype = prototype_factory.CreatePrototype(Type::PROTOTYPE_1);
    prototype->Method(90);
    delete prototype;

    std::cout << "\n";

    std::cout << "Let's create a Prototype 2 \n";

    prototype = prototype_factory.CreatePrototype(Type::PROTOTYPE_2);
    prototype->Method(10);

    delete prototype;
}


#pragma region Me
class PrototypeA
{
    virtual PrototypeA* Clone() = 0;
};
class VEHICULE : public PrototypeA
{
private:
    string brand = "brand";
    string model = "model";
    string color = "color";
    int speed =0;
public:
  inline  void SetBrand(const string& _brand) { brand = _brand; }
  inline  void SetModel(const string& _model) { model = _model; }
  inline  void SetColor(const string& _color) { color = _color; }
  inline  void SetSpeed(const int& _speed) { speed = _speed; }
public:
    VEHICULE()
    {

    }
    VEHICULE(const VEHICULE& car)
    {
        brand = car.brand;
        model = car.model;
        color = car.color;
        speed = car.speed;
    }
public:
    VEHICULE* Clone() override
    {
        return new VEHICULE(*this);
    }
    void Registre()
    {
        cout<< "brand: "<< brand <<endl;
        cout << "model: " << model << endl;
        cout << "color: " << color << endl;
        cout << "speed: " << speed << endl;
    }
};
class Bus : public VEHICULE
{
public:
    Bus* Clone() override
    {
        return new Bus(*this);
    }
};
class CAR : public VEHICULE
{
public:
    CAR* Clone() override
    {
        return new CAR(*this);
    }
};
class RegistryCar
{
private:
    map<string, VEHICULE> cache = map<string, VEHICULE>();
public :
    map<string, VEHICULE> GetCache() const{ return cache; }
public :
     RegistryCar()
    {
        
        CAR* car = new CAR();
        car->SetBrand("Bugatti");
        car->SetModel("Chiron");
        car->SetColor("Blue");
        car->SetSpeed(261);

        Bus* bus = new Bus();
        bus->SetBrand("Mercedes");
        bus->SetModel("Setra");
        bus->SetColor("White");
        bus->SetSpeed(600);

        
        cache.insert({ "Bugatti Chiron", *car });
        cache.insert({ "Mercedes Setra", *bus });

        delete car;
        delete bus;
    }
};
#pragma endregion








int main()
{
    
    RegistryCar registryCar = RegistryCar();

    VEHICULE* Mercedes;

    Mercedes = registryCar.GetCache().at("Bugatti Chiron").Clone();
    Mercedes->Registre();

    delete Mercedes;
    /*
    std::cout << "Let's create a Prototype 1\n";
    PrototypeFactory prototypeF= PrototypeFactory();
    Prototype* prototype = prototypeF.CreatePrototype(Type::PROTOTYPE_1);
    prototype->Method(90);
    delete prototype;

    std::cout << "\n";

    std::cout << "Let's create a Prototype 2 \n";

    prototype = prototypeF.CreatePrototype(Type::PROTOTYPE_2);
    prototype->Method(10);

    delete prototype;
    */
    return 0;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
