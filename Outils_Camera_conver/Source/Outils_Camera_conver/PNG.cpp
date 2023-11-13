// Fill out your copyright notice in the Description page of Project Settings.


#include "PNG.h"
#include "DrawDebugUtils.h"


#define SCALE_UNREAL unitUnreal
#define SCALE_DISTANCE distancePlayer * 0.666

APNG::APNG()
{
	PrimaryActorTick.bCanEverTick = true;
#if WITH_EDITOR
	PrimaryActorTick.bStartWithTickEnabled = true;

#endif

	cameraPng = CreateDefaultSubobject<UCameraComponent>("Camera PNG");
	cameraScene = CreateDefaultSubobject<UCameraComponent>("Camera Scene");

	cameraScene->SetupAttachment(cameraPng);
	cameraPng->SetupAttachment(RootComponent);
	cameraScene->SetRelativeLocation(FVector(cameraPng->GetForwardVector().X, cameraPng->GetForwardVector().Y*10, cameraPng->GetForwardVector().Z));

	Init();
}


void APNG::BeginPlay()
{
	Super::BeginPlay();

}
void APNG::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	DrawDebug();
	const float _scale_distance = SCALE_DISTANCE;

	const float _player = distancePlayer * SCALE_UNREAL / 2;
	const float _camera = _player + cameraPng->GetRightVector().Y * (distanceCamera * SCALE_UNREAL) + _scale_distance;
	

	cameraScene->SetRelativeLocation(FVector(_player, _camera, heightCamera* SCALE_UNREAL));
	cameraScene->SetWorldRotation(lookAtScene);
}


bool APNG::ShouldTickIfViewportsOnly() const
{
	return useDebug;
}

void APNG::DrawDebug()
{
	const float _scale_distance = SCALE_DISTANCE;

	const FVector _player =  cameraPng->GetRelativeLocation() + cameraPng->GetForwardVector()* (distancePlayer* SCALE_UNREAL);
	const FVector _camera = _player / 2 + cameraPng->GetRightVector() * (distanceCamera * SCALE_UNREAL) +_scale_distance;

	DRAW_DEBUG_LINE(cameraPng->GetRelativeLocation(), _player, Green)
		DRAW_DEBUG_LINE(_player / 2, _camera, Purple)
		DRAW_DEBUG_SPHERE(_player, 200, Green)
		DRAW_DEBUG_SPHERE(_camera, 100, Purple)
		DrawDebugLookAt(_camera);
}
void APNG::DrawDebugLookAt(const FVector& _camera)
{
	const FVector _lookAt = FVector(_camera.X, _camera.Y, _camera.Z * SCALE_UNREAL);
	DRAW_DEBUG_LINE(_camera, _lookAt, Red)
	DRAW_DEBUG_BOX(FVector(0,0,0), FVector(100, 100, 100), Red,1)
	
}

void APNG::Init()
{
	distancePlayer *=  SCALE_UNREAL;
	distanceCamera *= SCALE_UNREAL;
	heightCamera *= SCALE_UNREAL;
}
