// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include "CameraMovements.h"

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "CameraManagedComponent.generated.h"


UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class CCC_2023_API UCameraManagedComponent : public UActorComponent
{
	GENERATED_BODY()
		UPROPERTY(EditAnywhere, Category = "Manager")
		FString id = "Camera";
	UPROPERTY(VisibleAnywhere, BlueprintReadWrite, Category = "Manager", meta = (EditInline, AllowPrivateAccess))
		bool isManaged = false;
	TObjectPtr<ACameraMovements> cameraSystem = nullptr;
public:
	UCameraManagedComponent();
public:
	FORCEINLINE FString ID() const { return id; }
	UFUNCTION(BlueprintCallable, Category = "Manager") virtual void Enable();
	UFUNCTION(BlueprintCallable, Category = "Manager") virtual void Disable();
	 void RegisterCamera(FString _id);
protected:
	ACameraMovements* GetCameraMovementSystem()const { return Cast<ACameraMovements> (GetOwner()); }
	UFUNCTION(BlueprintCallable, Category = "Manager") virtual void RemoveCamera();

	virtual void BeginPlay() override;
	class UCameraManager* GetManager();
	void Init();
};
