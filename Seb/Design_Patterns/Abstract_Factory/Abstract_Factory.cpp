// Abstract_Factory.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;
/**
 * Each distinct product of a product family should have a base interface. All
 * variants of the product must implement this interface.
 */
class AbstractProductA {
public:
    virtual ~AbstractProductA() {};
    virtual std::string UsefulFunctionA() const = 0;
};

/**
 * Concrete Products are created by corresponding Concrete Factories.
 */
class ConcreteProductA1 : public AbstractProductA {
public:
    std::string UsefulFunctionA() const override {
        return "The result of the product A1.";
    }
};

class ConcreteProductA2 : public AbstractProductA {
    std::string UsefulFunctionA() const override {
        return "The result of the product A2.";
    }
};

/**
 * Here's the the base interface of another product. All products can interact
 * with each other, but proper interaction is possible only between products of
 * the same concrete variant.
 */
class AbstractProductB {
    /**
     * Product B is able to do its own thing...
     */
public:
    virtual ~AbstractProductB() {};
    virtual std::string UsefulFunctionB() const = 0;
    /**
     * ...but it also can collaborate with the ProductA.
     *
     * The Abstract Factory makes sure that all products it creates are of the
     * same variant and thus, compatible.
     */
    virtual std::string AnotherUsefulFunctionB(const AbstractProductA& collaborator) const = 0;
};

/**
 * Concrete Products are created by corresponding Concrete Factories.
 */
class ConcreteProductB1 : public AbstractProductB {
public:
    std::string UsefulFunctionB() const override {
        return "The result of the product B1.";
    }
    /**
     * The variant, Product B1, is only able to work correctly with the variant,
     * Product A1. Nevertheless, it accepts any instance of AbstractProductA as an
     * argument.
     */
    std::string AnotherUsefulFunctionB(const AbstractProductA& collaborator) const override {
        const std::string result = collaborator.UsefulFunctionA();
        return "The result of the B1 collaborating with ( " + result + " )";
    }
};

class ConcreteProductB2 : public AbstractProductB {
public:
    std::string UsefulFunctionB() const override {
        return "The result of the product B2.";
    }
    /**
     * The variant, Product B2, is only able to work correctly with the variant,
     * Product A2. Nevertheless, it accepts any instance of AbstractProductA as an
     * argument.
     */
    std::string AnotherUsefulFunctionB(const AbstractProductA& collaborator) const override {
        const std::string result = collaborator.UsefulFunctionA();
        return "The result of the B2 collaborating with ( " + result + " )";
    }
};

/**
 * The Abstract Factory interface declares a set of methods that return
 * different abstract products. These products are called a family and are
 * related by a high-level theme or concept. Products of one family are usually
 * able to collaborate among themselves. A family of products may have several
 * variants, but the products of one variant are incompatible with products of
 * another.
 */
class AbstractFactory {
public:
    virtual AbstractProductA* CreateProductA() const = 0;
    virtual AbstractProductB* CreateProductB() const = 0;
};

/**
 * Concrete Factories produce a family of products that belong to a single
 * variant. The factory guarantees that resulting products are compatible. Note
 * that signatures of the Concrete Factory's methods return an abstract product,
 * while inside the method a concrete product is instantiated.
 */
class ConcreteFactory1 : public AbstractFactory {
public:
    AbstractProductA* CreateProductA() const override {
        return new ConcreteProductA1();
    }
    AbstractProductB* CreateProductB() const override {
        return new ConcreteProductB1();
    }
};

/**
 * Each Concrete Factory has a corresponding product variant.
 */
class ConcreteFactory2 : public AbstractFactory {
public:
    AbstractProductA* CreateProductA() const override {
        return new ConcreteProductA2();
    }
    AbstractProductB* CreateProductB() const override {
        return new ConcreteProductB2();
    }
};

/**
 * The client code works with factories and products only through abstract
 * types: AbstractFactory and AbstractProduct. This lets you pass any factory or
 * product subclass to the client code without breaking it.
 */

void ClientCode(const AbstractFactory& factory) {
    const AbstractProductA* product_a = factory.CreateProductA();
    const AbstractProductB* product_b = factory.CreateProductB();
    std::cout << product_b->UsefulFunctionB() << "\n";
    std::cout << product_b->AnotherUsefulFunctionB(*product_a) << "\n";
    delete product_a;
    delete product_b;
}
/*====================================================*/
// Interface de ProduitX
// les variantes de produitsX
//Interface d'Usine X
// Les usines qui produits differents produit d'une m^me famille X
// La classe CréateurX
//le code client X

//Interface de différent type de produit
class AbstractChaise
{
public:
    virtual void Assemble() = 0;
  
};
class AbstractCanape
{
public:
    virtual void Assemble() = 0;
};
class AbstractTable
{
public:
    virtual void Assemble() = 0;
};
// Les varientes de produits
//Différente chaise
class ChaiseVictorienne : public AbstractChaise
{
public:
    void Assemble() override
    {
        cout << "ChaiseVictorienne" << endl;
    }

};
class ChaiseModerne : public AbstractChaise
{
public:
    void Assemble() override
    {
        cout << "ChaiseModerne" << endl;
    }

};
class VielleChaise : public AbstractChaise
{
public:
    void Assemble() override
    {
        cout << "VielleChaise" << endl;
    }

};
//Différente Canaper
class CanapeVictorienne : public AbstractCanape
{
public:
    void Assemble() override
    {
        cout << "CanapeVictorienne" << endl;
    }

};
class CanapeModerne : public AbstractCanape
{
public:
    void Assemble() override
    {
        cout << "CanapeModerne" << endl;
    }

};
class CanapeVieux : public AbstractCanape
{
public:
    void Assemble() override
    {
        cout << "CanapeChaise" << endl;
    }

};
//Différente Table
class TableVictorienne : public AbstractTable
{
public:
    void Assemble() override
    {
        cout << "TableVictorienne" << endl;
    }

};
class TableModerne : public AbstractTable
{
public:
    void Assemble() override
    {
        cout << "TableModerne" << endl;
    }

};
class TableVieux : public AbstractTable
{
public:
    void Assemble() override
    {
        cout << "TableChaise" << endl;
    }

};

//Interface d'Usine
class AbstractFactoryCarpet
{ 
public:
    virtual AbstractCanape* CreateCanape() = 0;
    virtual AbstractTable* CreateTable() = 0;
    virtual AbstractChaise* CreateChaise() = 0;
};
// Les usines qui produits differents produit d'une m^me famille

class VictorienneFactoryCarpet : public AbstractFactoryCarpet
{
public:
    virtual CanapeVictorienne* CreateCanape() override
    {   
        return new CanapeVictorienne();
    }
    virtual TableVictorienne* CreateTable() override {
        return new TableVictorienne();
    }
    virtual ChaiseVictorienne* CreateChaise() override {
        return new ChaiseVictorienne();
    }
};
class VieuxFactoryCarpet : public AbstractFactoryCarpet
{
public:
    virtual AbstractCanape* CreateCanape() override {
        return new CanapeVieux();
    }
    virtual AbstractTable* CreateTable()override {
        return new TableVieux();
    }
    virtual AbstractChaise* CreateChaise() override {
        return new VielleChaise();
    }
};
class ModerneFactoryCarpet : public AbstractFactoryCarpet
{
public:
    virtual AbstractCanape* CreateCanape() override {
        return new CanapeModerne();
    }
    virtual AbstractTable* CreateTable()override {
        return new TableModerne();
    }
    virtual AbstractChaise* CreateChaise()override {
        return new ChaiseModerne();
    }
};
// La classe Créateur
class Createur
{
    AbstractFactoryCarpet* UsineVieille = new VieuxFactoryCarpet();
    AbstractFactoryCarpet* UsineModerne = new ModerneFactoryCarpet();
    AbstractFactoryCarpet* UsineVictorienne = new VictorienneFactoryCarpet();
public:
    void CreateVictorienne()
    {
        cout << "usine Victorienne:" << endl;
       
       AbstractCanape* _canperVictorien= UsineVictorienne->CreateCanape();
       AbstractChaise* _chaiseVitorienne = UsineVictorienne->CreateChaise();
       AbstractTable* _tableVictorien = UsineVictorienne->CreateTable();

       _canperVictorien->Assemble();
       _chaiseVitorienne->Assemble();
       _tableVictorien->Assemble();

       delete _canperVictorien;
       delete _chaiseVitorienne;
       delete _tableVictorien;
    }
    void CreateVieux()
    {
        cout << "usine Vieux:" << endl;
        AbstractCanape* _canperVictorien = UsineVieille->CreateCanape();
        AbstractChaise* _chaiseVitorienne = UsineVieille->CreateChaise();
        AbstractTable* _tableVictorien = UsineVieille->CreateTable();

        _canperVictorien->Assemble();
        _chaiseVitorienne->Assemble();
        _tableVictorien->Assemble();

        delete _canperVictorien;
        delete _chaiseVitorienne;
        delete _tableVictorien;
    }
    void CreateModerne()
    {
        cout << "usine Moderne:" << endl;
        AbstractCanape* _canperVictorien = UsineModerne->CreateCanape();
        AbstractChaise* _chaiseVitorienne = UsineModerne->CreateChaise();
        AbstractTable* _tableVictorien = UsineModerne->CreateTable();

        _canperVictorien->Assemble();
        _chaiseVitorienne->Assemble();
        _tableVictorien->Assemble();

        delete _canperVictorien;
        delete _chaiseVitorienne;
        delete _tableVictorien;
    }
};
//Client
class Client
{
public:
    void Create()
    {
        Createur* _createur = new Createur();
        _createur->CreateModerne();
        _createur->CreateVictorienne();
        _createur->CreateVieux();
        delete _createur;
    
    }
};


int main() {
   /* std::cout << "Client: Testing client code with the first factory type:\n";
    ConcreteFactory1* f1 = new ConcreteFactory1();
    ClientCode(*f1);
    delete f1;
    std::cout << std::endl;
    std::cout << "Client: Testing the same client code with the second factory type:\n";
    ConcreteFactory2* f2 = new ConcreteFactory2();
    ClientCode(*f2);
    delete f2;*/
    Client client = Client();
    client.Create();

    return 0;
}
