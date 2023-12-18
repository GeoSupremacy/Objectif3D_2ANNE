#pragma once

#define WORLD GetWorld()
#define DELTATIME WORLD->DeltaTimeSeconds


#define CREATE(component,name) CreateDefaultSubobject<component>(name);
#define ATTACH_TO(element, to) element->SetupAttachment(to);
#define FIRST_PLAYER_C GetWorld()->GetFirstPlayerController()
#define OWNER GetOwner()
#define LERP(A, B, T) FMath::Lerp(A, B, T)

#define BIND(eventName, owner, name) eventName.AddDynamic(owner, name)
#define INVOKE(eventName,...) eventName.Broadcast(__VA_ARGS__);

#define BIND_ACTION(input,object, funcName) BindAction(input, ETriggerEvent::Triggered, object, funcName);

