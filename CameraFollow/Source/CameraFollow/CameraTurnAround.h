// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include "CameraOrbitSettings.h"


#include "CoreMinimal.h"
#include "CameraMovement.h"
#include "CameraTurnAround.generated.h"

/**
 * 
 */
UCLASS()
class CAMERAFOLLOW_API ACameraTurnAround : public ACameraMovement
{
	GENERATED_BODY()
    UPROPERTY()
        float angle = 0;
public :
    FVector3d GetFinaltPosition() override { return RotationPoint() + GetTargetPosition(); }
    
private:
    virtual void Tick(float DeltaTime) override;
    void DrawDebug() override;
protected:
    void UpdateCameraPosition() override { SetActorLocation(GetFinaltPosition()); }
  

    FVector3d RotationPoint()
    {
       
        TObjectPtr<UCameraOrbitSettings> _set = Cast<UCameraOrbitSettings>(CameraSettings);
        float _radius = _set ? _set->Radius(): 1;
        angle = ComputeAngle();
        float _x = FMath::Cos(FMath::DegreesToRadians(angle)) * _radius,
            _y = FMath::Sin(FMath::DegreesToRadians(angle)) * _radius;
        return FVector3d(_x, _y, 0);
       
    }

    float ComputeAngle() { return GetWorld()->LastRenderTime * 360; }
};
