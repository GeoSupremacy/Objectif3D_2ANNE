// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "SingletonPattern.generated.h"



UCLASS()
//Template
 class MANAGERARCHI_UNREAL_API ASingletonPattern : public AActor
{
    GENERATED_BODY()
private:
   // template<typename T>
	 //static inline  T* instance = nullptr;
	
    // ASingletonPattern(ASingletonPattern& copy) = delete;
  
public:
    ASingletonPattern() {}
   // template<typename T>
   // static inline T* GetInstance() { return instance; }
  //  template<typename T>
   /*  void InitSingleton()
     {
         if (instance<T>)
         {
             Destroy(true);
             return;
         }

         instance<T> = new T;

     }
     */
//private:
  //  virtual void BeginPlay() override { Super::BeginPlay(); InitSingleton(); }
};
