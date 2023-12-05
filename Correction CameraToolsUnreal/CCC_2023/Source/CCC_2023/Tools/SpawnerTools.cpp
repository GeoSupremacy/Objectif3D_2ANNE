// Fill out your copyright notice in the Description page of Project Settings.


#include "SpawnerTools.h"

// Sets default values
ASpawnerTools::ASpawnerTools()
{
 	PrimaryActorTick.bCanEverTick = true;
#if WITH_EDITOR
	PrimaryActorTick.bStartWithTickEnabled = true;
#endif
	icon = CreateDefaultSubobject<UBillboardComponent>("Icon");
	RootComponent = icon;
}


void ASpawnerTools::AddNewItems(FString _id, TArray<AActor*> _items)
{

}

void ASpawnerTools::BeginPlay()
{
	Super::BeginPlay();
	
}
void ASpawnerTools::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	DrawAllModules();
}

bool ASpawnerTools::ShouldTickIfViewportsOnly() const
{
	return true;
}



void ASpawnerTools::Spawn()
{
	if(!currentmodule)
		return;
	currentmodule->Spawn(this);
}

void ASpawnerTools::Delete()
{
}

void ASpawnerTools::DrawAllModules()
{
	for (size_t i = 0; i < modules.Num(); i++)
	{
		if (modules[i] && modules[i]->GetModuleEnable())
			modules[i]->DrawDebug(GetWorld(), GetActorLocation());
	}
}

TSubclassOf<AActor> ASpawnerTools::GetRandomItem()
{
	const int _rmd = FMath::RandRange(0, items.Num()-1);
	
	return items[_rmd];
}
