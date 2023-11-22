#pragma once
#define WORLD GetWorld()
#define USE_DEBUG 1

#define LOG( msg, ...) if(USE_DEBUG) UE_LOG(LogTemp, Display, TEXT(msg), __VA_ARGS__)
#define LOG_WARNING( msg, ...) if(USE_DEBUG) UE_LOG(LogTemp, Warning, TEXT(msg), __VA_ARGS__)
#define LOG_ERROR( msg, ...) if(USE_DEBUG) UE_LOG(LogTemp, Error, TEXT(msg), __VA_ARGS__)

#define SCREEN_DEBUG_MESSAGE_ERROR(key, timeToDisplay, message) if(USE_DEBUG) GEngine->AddOnScreenDebugMessage(key, timeToDisplay, FColor::Red,TEXT(message));
#define SCREEN_DEBUG_MESSAGE_WARNING(key, timeToDisplay, message) if(USE_DEBUG) GEngine->AddOnScreenDebugMessage(key, timeToDisplay, FColor::Yellow,TEXT(message));

#define DRAW_SPHERE( from, radius, color, size) \
	if (USE_DEBUG) DrawDebugSphere(WORLD, from, radius, 20, FColor::color, false, -1,0 , size);

#define DRAW_SPHERE_DEF( from, radius,def , color, size)\
	if (USE_DEBUG)\
		DrawDebugSphere(WORLD, from, radius, def, color, false, -1,0 , size);

#define DRAW_BOX( from, extents, color, size) \
	if (USE_DEBUG)\
		DrawDebugBox(WORLD, from, extents, color, false, -1,0 , size);

#define DRAW_LINE( from, to, color, size) \
	if (USE_DEBUG)\
	 	DrawDebugLine(WORLD, from, to, color, false, -1,0 , size);

#define DRAW_TEXT( from, text, color, size) \
	if (USE_DEBUG)\
		 DrawDebugString(WORLD, from, text, nullptr, color,DELTATIME , false, size);

#define LERP_COLOR(from, to, t) UKismetMathLibrary::LinearColorLerp(from.ReinterpretAsLinear(), to.ReinterpretAsLinear(), t).ToFColor(true);
#define LERP(from,to,by) FMath::Lerp(from, to, by)
#define LERP_PITCH_ROTATION(from,to,by) FRotator(LERP(from,to,by), 0 , 0)
#define LERP_YAW_ROTATION(from,to,by) FRotator(0, LERP(from,to,by), 0)
#define LERP_ROLL_ROTATION(from,to,by) FRotator(0, 0, LERP(from,to,by))

#define CREATE(element,name) CreateDefaultSubobject<element>(name);
#define ATTACH_ROOT(element) element->SetupAttachment(RootComponent);
#define ATTACH_TO(attach, to) attach->SetupAttachment(to);


#define FIRST_PLAYER_CONTROLLER GetWorld()->GetFirstPlayerController()->GetPawn()

#define DELTATIME GetWorld()->DeltaTimeSeconds

#define ACTOR GetOwner()

#define INVOKE(eventName, ...) eventName.Broadcast( __VA_ARGS__);

#define MAX_WALKSPEED_CHARACTER GetCharacterMovement()->MaxWalkSpeed

#define ARM_ROTATION springArm->GetRelativeRotation()

#define FORWARD_VECTOR GetActorForwardVector()
#define RIGHT_VECTOR GetActorRightVector()


#define LINETRACE(from, to, result) UKismetSystemLibrary::LineTraceSingleForObjects(GetWorld(), from, to, objectLayer, true, TArray<AActor*>(), EDrawDebugTrace::ForOneFrame, _result, false, FLinearColor::Red, FLinearColor::Green, 5);
#define LINETRACE_BACK_COLOR(from, to, result, color) UKismetSystemLibrary::LineTraceSingleForObjects(GetWorld(), from, to, objectLayer, true, TArray<AActor*>(), EDrawDebugTrace::ForOneFrame, _result, false, FLinearColor::color, FLinearColor::Green, 5);

#define LENGTH(Vector) FMath::Square(Vector.X*Vector.X + Vector.Y*Vector.Y +Vector.Z*Vector.Z)
#define NORMALIZED(Vector, length) Vector/length;