// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include "CameraManagedComponent.h"
#include "CoreMinimal.h"
#include "UObject/NoExportTypes.h"
#include "CameraManager.generated.h"

/**
 * 
 */
UCLASS(Blueprintable)
class MANAGERARCHI_UNREAL_API UCameraManager : public UObject
{
	GENERATED_BODY()
	UPROPERTY(VisibleAnywhere)
		TMap<FString, UCameraManagedComponent*> cameras = TMap<FString, UCameraManagedComponent*>();
public:
	bool AddCamera(UCameraManagedComponent* _camera);
public:
	FORCEINLINE void SayHello() { UE_LOG(LogTemp, Warning, TEXT("SayHello")); }
};
