#include "../Source/CCC_2023/Public/Tools/LineModule.h"
#include "../Source/CCC_2023/Tools/SpawnerTools.h"
// Fill out your copyright notice in the Description page of Project Settings.

void ULineModule::DrawDebug(UWorld* _wordl, const FVector& _origin)
{
	for (size_t i = 0; i < itemNumber * gap; i+=gap)
	{
		const FVector _point= FVector(0,i,0);
		DrawDebugSphere(_wordl, _point, 50, 20, FColor::Green);
	}
	DrawDebugLine(_wordl, _origin, _origin+FVector(0, gap * itemNumber,0),FColor::Green);
}
TArray<AActor*> ULineModule::Spawn(ASpawnerTools* _tool)
{
	for (size_t i = 0; i < itemNumber * gap; i += gap)
	{
		const FVector _point = _tool->GetActorLocation() +FVector(0, i, 0);
		AActor* _item = _tool->GetWorld()->SpawnActor<AActor>(_tool->PickItem(), _point, FRotator());
	}
	return TArray<AActor*>();
}