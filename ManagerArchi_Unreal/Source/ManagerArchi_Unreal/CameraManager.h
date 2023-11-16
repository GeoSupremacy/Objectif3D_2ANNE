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
	//UPROPERTY(EditAnywhere, Category ="Manager")
		//TsubclassOf<ACameraFooll> camerafollowDefault = nullptr;
	//UPROPERTY(EditAnywhere, Category ="Manager")
		//TsubclassOf<AcameraOrbit> cameraOrbitDefault = nullptr;
public:
	bool AddCamera(UCameraManagedComponent* _camera);
	bool RemoveCamera(UCameraManagedComponent* _camera);
	UFUNCTION(BlueprintCallable) void DisableCamera(FString _id);
	UFUNCTION(BlueprintCallable) void EnableCamera(FString _id);
};
