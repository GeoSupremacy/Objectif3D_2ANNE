#include "CameraFollowActor.h"

void ACameraFollowActor::UpdateCameraPosition()
{
	TObjectPtr<UCameraSettingsFollow> _set = Cast<UCameraSettingsFollow>(CameraSettings);

	if(_set->FMovementType() == MovementType::Lerp)
        SetActorLocation(FMath::Lerp(GetActorLocation(), GetTargetPosition(), CameraSettings->GetSpeed() * GetWorld()->DeltaTimeSeconds));  
    else
        SetActorLocation(FMath::VInterpConstantTo(GetActorLocation(), GetTargetPosition(),  GetWorld()->DeltaTimeSeconds, CameraSettings->GetSpeed()));  

        
}


