// Fill out your copyright notice in the Description page of Project Settings.

#include "../Utils.h"
#include "../DebugUtils.h"
#include "../DrawDebugUtils.h"
#include "Kismet/KismetSystemLibrary.h"
#include "Player/PlayableCharacter.h"
#include "GUI/UI_HUD_Menu.h"
#include "GPE/Source.h"


#pragma region Constructeur
ASource::ASource()
{
	PrimaryActorTick.bCanEverTick = true;
	mesh = CREATE(UStaticMeshComponent, "SphereMesh");
	ATTACH_TO(mesh, RootComponent)
	mesh->SetStaticMesh(LoadObject<UStaticMesh>(this, TEXT("'/Engine/BasicShapes/Sphere.Sphere'")));

}
#pragma endregion 

#pragma region UE_METHOD
void ASource::BeginPlay()
{
	Super::BeginPlay();
	Bind();
	Registre();
	//InitMaterial(); tentative de modifier lacouleur du matérial pour montrer quelle couleur du rayon
}
void ASource::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	Reflection();
	//Pour afficher qu'elle couleur
	DRAW_SPHERE(GetActorLocation(), 100, color, 16)
}
#pragma endregion 

#pragma region METHOD
void ASource::Reflection()
{
	FHitResult  _result;
	bool _hit;
	TArray<AActor*> _me = { this };
	//Tous les réflecteurs lié à la source
	for (auto _reflection : allReflectionLink)
	{
		_hit = UKismetSystemLibrary::LineTraceSingleForObjects(WORLD, GetActorLocation(), _reflection->FinalPosition(), interactLayer, true, _me, EDrawDebugTrace::ForOneFrame, _result, true);
		if (_hit)
		{
			
			//Coupe le rayon si le joueur ou tous autre obstacles
			if (Cast<APlayableCharacter>(_result.GetActor()) || !Cast<AReflector>(_result.GetActor()))
			{
				
				//Coup ou non le contact avec un réflecteur
				_reflection->SetContact(false);
			}
			else
			{
				//Le rayon en debug
				
				DRAW_LINE(GetActorLocation(), _reflection->FinalPosition(), color, 3)
				//Affiche une sphere au dessus pour dire qu'elle reflecteur est lié directement par la source
				DRAW_SPHERE(_reflection->GetActorLocation() + _reflection->GetActorUpVector() * 400, 25, FColor::Blue, 2)
					_reflection->SetContact(true);
			}
		}
		else
		{
	
			_reflection->SetContact(false);
		}
	}
}
void ASource::Remove(AReflector* _reflector)
{
	if (!allReflectionLink.Contains(_reflector))
		return;
	_reflector->RemoveLink();
	_reflector->SetContact(false);
	allReflectionLink.Remove(_reflector);
}
void ASource::Dispersion(AReflector* _reflector)
{

	if (allReflectionLink.Contains(_reflector))
		return;
	
	//Pour que le reflecteurs renvoit un rayon de même couleur
	_reflector->SetColor(color);
	allReflectionLink.Add(_reflector);
}
void ASource::Registre()
{
	//Création d'un icone spécifique pour la source dynamic userWidget
	INVOKE(onRegistre, "Source", this);
}
#pragma endregion 

#pragma region INIT
void ASource::InitMaterial()
{
	dynamicMaterialColor = mesh->CreateDynamicMaterialInstance(0);
	FHashedMaterialParameterInfo _param;
	_param.Name = FScriptName("SourceColor");
	dynamicMaterialColor->GetVectorParameterValue(_param, sourceColor);
	dynamicMaterialColor->SetVectorParameterValue("SourceColor", sourceColor);
}
void ASource::Bind()
{
	APlayableCharacter* _player = Cast< APlayableCharacter>(FPC->GetPawn());
	if (!_player)
		return;

	_player->BIND(OnLinkSource(), this, &ASource::Dispersion);
	_player->BIND(OnDisableAllLink(), this, &ASource::Remove);

	AUI_HUD_Menu* hud = Cast<AUI_HUD_Menu>(FPC->GetHUD());
	if (!hud)
		return;

	BIND(OnRegistre(), hud->Get(), &AUI_HUD_Menu::Create);
}
#pragma endregion 
