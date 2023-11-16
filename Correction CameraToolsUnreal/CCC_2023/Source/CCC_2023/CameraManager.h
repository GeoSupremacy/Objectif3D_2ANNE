// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include "CameraManagedComponent.h"
#include "CameraFollow.h"
#include "OrbitCamera.h"


#include "CoreMinimal.h"
#include "UObject/NoExportTypes.h"
#include "CameraManager.generated.h"

/**
 * 
 */
UCLASS(Blueprintable)
class CCC_2023_API UCameraManager : public UObject
{
	GENERATED_BODY()

	UPROPERTY(VisibleAnywhere)
		TMap<FString, UCameraManagedComponent*> cameras = TMap<FString, UCameraManagedComponent*>();
	UPROPERTY(EditAnywhere, Category ="Manager")
		TSubclassOf<ACameraFollow> camerafollowDefault = nullptr;
	UPROPERTY(EditAnywhere, Category ="Manager")
		TSubclassOf<AOrbitCamera> cameraOrbitDefault = nullptr;
public:
	bool AddCamera(UCameraManagedComponent* _camera);
	bool RemoveCamera(UCameraManagedComponent* _camera);
	UFUNCTION(BlueprintCallable) void DisableCamera(FString _id);
	UFUNCTION(BlueprintCallable) void EnableCamera(FString _id);
	UFUNCTION(BlueprintCallable) void SpawnCameraFollow(FString _id, AActor* _target);
	UFUNCTION(BlueprintCallable) void SpawnCameraOrbit(FString _id, AActor* _target);
	template <class T>
void SpawnCamera(TSubclassOf<T> _subClass, FString _id, AActor* _target)
	{
		T* _instance = GetWorld()->SpawnActor<T>(_subClass);
		 

		_instance->SetTarget(_target);

		UCameraManagedComponent* _comp = _instance->GetComponentByClass < UCameraManagedComponent > ();
		if(_comp)
			_comp->RegisterCamera(_id);
	
	}
};
