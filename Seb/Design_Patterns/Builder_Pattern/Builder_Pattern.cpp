#include <iostream>
#include <vector>
using namespace std;
class Car
{
private:
    int id;
    string model;
    string color;
    double height;
    double weight;
    int numberDoor;
public:
     Car(int _id, string _model, string _color, double _height, double _weight, int _numberDoor) 
       :  id { _id }, model{ _model }, color{ _color }, height{ _height }, weight{ _weight }, numberDoor{ _numberDoor }{}
     void Result() const 
     {
         cout<<"id: " << id << endl;
         cout << "model: " << model << endl;
         cout << "color: " << color << endl;
         cout << "height: " << height << endl;
         cout << "weight: " << weight << endl;
         cout << "numberDoor: " << numberDoor <<endl;
     }
};

class BaseBuilderCar
{
protected:
    int id;
    string model;
    string color;
    double height;
    double weight;
    int numberDoor;
public:
    inline void Id(int _id) { id = _id; }
    inline void Model(string _model) { model = _model; }
    inline void Color(string _color) { color = _color; }
    inline void Height(double _height) { height = _height; }
    inline void Weight(double _weight) { weight = _weight; }
    inline void NumberDoor(int _numberDoor) { numberDoor = _numberDoor;}
    inline virtual Car Build() const { return Car(id, model, color, height, weight, numberDoor); }
};
class BuilderTruck : public BaseBuilderCar
{

public:
    inline Car Build() const override  { return Car(this->id, this->model, this->color, this->height, this->weight, 2); }
};

class BuilderMoto : public BaseBuilderCar
{

public:
    inline Car Build() const override { return Car(this->id, this->model, this->color, this->height, this->weight, 2); }
};

class Director
{
private:
    BaseBuilderCar* baseBuilderCar = nullptr;
public:
    BaseBuilderCar* BuilderCar() const {
        return baseBuilderCar;
    }
    Director() { }
    ~Director() { delete baseBuilderCar; baseBuilderCar = nullptr; }
    Car BuildMoto()
    {
        if (!baseBuilderCar)
            throw;
        baseBuilderCar->Id(10);
        baseBuilderCar->Model("Moto");
        baseBuilderCar->Color("Red");
        return baseBuilderCar->Build();
    }
    void Result() const 
    {
        if (!baseBuilderCar)
            throw;
        Car* _car = new  Car(baseBuilderCar->Build());
        _car->Result();
        delete _car;
    }
    inline void SetBuilder(BaseBuilderCar* _baseBuilderCar)
    {
        baseBuilderCar = _baseBuilderCar;
    }
};

int main()
{
   
    BuilderMoto _BuilderMoto = BuilderMoto();
    Director _dir = Director();
    _dir.SetBuilder(&_BuilderMoto);
    _dir.BuilderCar()->Id(13);

    _dir.Result();
    return 0;
}

