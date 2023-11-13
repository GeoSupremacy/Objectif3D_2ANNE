// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include "Camera/CameraComponent.h"


#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "PNG.generated.h"

UCLASS()
class OUTILS_CAMERA_CONVER_API APNG : public AActor
{
	GENERATED_BODY()
private:	
	UPROPERTY(Editanywhere)
		bool useDebug =true;

	UPROPERTY(Editanywhere)
		TObjectPtr<UCameraComponent> cameraScene = nullptr;
	UPROPERTY(Editanywhere)
		TObjectPtr<UCameraComponent> cameraPng = nullptr;


	UPROPERTY(Editanywhere, Category ="Camera Scene Settings")
		float distanceCamera = 0.0f;
	UPROPERTY(Editanywhere, Category = "Camera Scene Settings")
		float heightCamera = 0.0f;
	UPROPERTY(Editanywhere, Category = "Camera Scene Settings")
		FRotator lookAtScene = FRotator(0,-95,0);

	UPROPERTY(Editanywhere)
		float distancePlayer = 0.0f;

	
	const float unitUnreal = 100;
public:	
	APNG();

private:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	bool ShouldTickIfViewportsOnly() const override;
private:
	void DrawDebug();
	void DrawDebugLookAt(const FVector& _camera);
	void Init();
};
