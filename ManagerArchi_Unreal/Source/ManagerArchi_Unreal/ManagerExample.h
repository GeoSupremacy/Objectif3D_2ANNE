// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include <map>
#include "ItemManaged.h"

using namespace std;


#include "CoreMinimal.h"
#include "SingletonPattern.h"
#include "ManagerExample.generated.h"

/**
 * 
 */
UCLASS()
class MANAGERARCHI_UNREAL_API AManagerExample : public ASingletonPattern
{
	GENERATED_BODY()
		/*
private:
		map<string, AItemManaged> items =  map<string, AItemManaged>();
public:
	FORCEINLINE	map<string, AItemManaged> GetItems() const { return items; }
public:
	void Add(AItemManaged& _item);
	void Remove(AItemManaged& _item);
	//void EnableItem(string _item) { items[_item].Enable(); }
	//void DisableItem(string _item) { items[_item].Disable(); }

	//void EnableItem(AItemManaged& _item) { items[_item.GetID()].Enable(); }
	//void DisableItem(AItemManaged& _item) { items[_item.GetID()].Disable(); }
	*/
};
