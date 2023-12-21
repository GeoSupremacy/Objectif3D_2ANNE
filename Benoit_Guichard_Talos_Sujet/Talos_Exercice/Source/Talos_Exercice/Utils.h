#pragma once

#define WORLD GetWorld()
#define DELTATIME WORLD->DeltaTimeSeconds

#define PLAYER_CONTROLLER GetWorld()->GetFirstPlayerController()
#define CREATE(component,name) CreateDefaultSubobject<component>(name);
#define ATTACH_TO(element, to) element->SetupAttachment(to);
#define FPC GetWorld()->GetFirstPlayerController()
#define OWNER GetOwner()
#define LERP(A, B, T) FMath::Lerp(A, B, T)

#define BIND(eventName, owner, name) eventName.AddDynamic(owner, name)
#define INVOKE(eventName,...) eventName.Broadcast(__VA_ARGS__);

#define BIND_ACTION(input,object, funcName) BindAction(input, ETriggerEvent::Triggered, object, funcName);

#define DEPROJECT_SCREEN_POSITION_TO_WORLD(ScreenX,ScreenY,WorldLocation, worldDirection) PLAYER_CONTROLLER->GetPawn()->DeprojectScreenPositionToWorld(ScreenX,ScreenY,WorldLocation, worldDirection);
#define DEPROJECT_MOUSE_POSITION_TO_WORLD(WorldLocation,worldDirection) PLAYER_CONTROLLER->GetPawn()->DeprojectMousePositionToWorld(WorldLocation, worldDirection);
#define VIEWPORT_SIZE(SizeX,SizeY) PLAYER_CONTROLLER->GetPawn()->GetViewportSize(SizeX,SizeY);