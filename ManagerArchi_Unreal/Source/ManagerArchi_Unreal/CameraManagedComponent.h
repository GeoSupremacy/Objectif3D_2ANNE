// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "CameraManagedComponent.generated.h"


UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class MANAGERARCHI_UNREAL_API UCameraManagedComponent : public UActorComponent
{
	GENERATED_BODY()
	UPROPERTY(EditAnywhere, Category = "Manager")
		FString id = "Camera";
	UPROPERTY(VisibleAnywhere, Category = "Manager", meta =(EditInline))
		bool isManaged = false;
public:	
	UCameraManagedComponent();
public:
	FORCEINLINE FString ID() const { return id; }
protected:
	virtual void BeginPlay() override;
	class UCameraManager* GetManager();
		
};
