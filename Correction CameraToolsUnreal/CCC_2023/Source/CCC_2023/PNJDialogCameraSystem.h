// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "PNJCameraSettings.h"
#include "PNJDialogCameraSystem.generated.h"


UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class CCC_2023_API UPNJDialogCameraSystem : public UActorComponent
{
    GENERATED_BODY()
     UPROPERTY(EditAnywhere)
        TObjectPtr<AActor> target = nullptr;
    UPROPERTY(EditAnywhere)
        TObjectPtr<UPNJCameraSettings> settings;
    UPROPERTY()
        TObjectPtr<ACameraPNJ> activeCamera = nullptr;
public:	
    FORCEINLINE TObjectPtr<AActor> Target() const { return target; }
    FORCEINLINE float DistanceToTarget() { return FVector::Distance(CurrentPNJLocation(), CurrentTargetPosition()); }
    FORCEINLINE float Radius() { return (DistanceToTarget() / 2) ; }
    FORCEINLINE FVector CurrentPNJLocation() const { return GetOwner()->GetActorLocation(); }
    FORCEINLINE FVector CurrentTargetPosition()
    {
        if (!target)
            return FVector(0);
        return target->GetActorLocation();
    }
    FORCEINLINE FVector TargetPivot() 
    {
        return settings ? FMath::Lerp(CurrentPNJLocation(), CurrentTargetPosition(), settings->TargetPivotLocation()) : FVector(0);
    }
    FORCEINLINE FVector FinalCameraLocation()  
    { 
        return settings ? FinalCameraLocationWithoutHeight() + settings->Height() : FVector(0);
    }
    FORCEINLINE FVector FinalCameraLocationWithoutHeight()
    {
        return settings ? GetCameraPosition(settings->Angle(), Radius()) : FVector(0);
    }
    #pragma endregion
	UPNJDialogCameraSystem();
    FORCEINLINE void SetTarget(AActor* _target) { target = _target; }
    void InitCameraDialog();
protected:
    void UpdateCameraLocation(); 
    FVector GetCameraPosition(const float& _angle = 45, const float& _radius = 10);
	virtual void BeginPlay() override;
	virtual void TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;
    void DrawDebug();
};
