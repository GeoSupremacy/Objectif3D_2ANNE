


#include "../Utils.h"
#include"../DrawDebugUtils.h"
#include"../DebugUtils.h"
#include "Kismet/KismetSystemLibrary.h"
#include "GPE/Source.h"
#include "GPE/Locker.h"
#include "GUI/UI_HUD_Menu.h"

#include "GPE/Reflector.h"



#pragma region Constructor
AReflector::AReflector()
{
	PrimaryActorTick.bCanEverTick = true;
#if WITH_EDITOR 
	PrimaryActorTick.bStartWithTickEnabled = true;
#endif
}
#pragma endregion

#pragma region UE_METHOD
void AReflector::BeginPlay()
{
	Super::BeginPlay();
	Bind();
	Registre();
}
void AReflector::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	Target();
	AllReflect();
	DrawDebug();
}
bool AReflector::ShouldTickIfViewportsOnly() const
{
	return shouldTickIfViewportsOnly;
}
#pragma endregion

#pragma region METHOD
void AReflector::LinkSource()
{
	
	if (!isDetected)
		return;
	

	if (resultTarget.GetActor() != Cast<ASource>(resultTarget.GetActor()))
		return;

	isDetected = false;
	SCREEN_DEBUG_MESSAGE_WARNING(0, "LinkSource")
	
	INVOKE(onLinkSource, this)
}
void AReflector::LinkReflector()
{
	if (!isDetected || !asContact)
		return;
	
	if (!Cast<AReflector>(resultTarget.GetActor()))
		return;

	if(allLinkReflector.Contains((AReflector*)resultTarget.GetActor()))
		return;
	isDetected = false;
	allLinkReflector.Add((AReflector*)resultTarget.GetActor());


}
void AReflector::Registre()
{
	INVOKE(onRegistre, "Reflector", this);
}
void AReflector::LinkLocker()
{
	SCREEN_DEBUG_MESSAGE_ERROR(1, "Pass")
	if (!isDetected || !asContact)
		return;
	SCREEN_DEBUG_MESSAGE_ERROR(1, "isDetected")
	if (resultTarget.GetActor() != Cast<ALocker>(resultTarget.GetActor()))
		return;
	SCREEN_DEBUG_MESSAGE_ERROR(1, "LinkLocker")
	//isDetected = false;
	INVOKE(onLinkLocker, this)
}
void AReflector::Target()
{
	//Quand le joueur prend un réflecteur permet de faire des liens là ou le joueur cible
	if (!takeIt ||!character)
		return;


	TArray<AActor*> _this = { this };
	// Ou le joueur cible
	const FVector _end =FinalPosition()+ character->GetActorForwardVector()* 1000;
	
	bool _hisHit = UKismetSystemLibrary::LineTraceSingleForObjects(WORLD, FinalPosition(), _end, raySourceLayer, false, _this, EDrawDebugTrace::ForOneFrame, resultTarget, true);
	
	if (_hisHit)
	{
		//Vérifie  s' il ne touche  pas un obstacle
		if (Cast<AReflector>(resultTarget.GetActor()) || Cast<ASource>(resultTarget.GetActor()) || Cast<ALocker>(resultTarget.GetActor()))
		{

			DRAW_SPHERE(resultTarget.GetActor()->GetActorLocation() + resultTarget.GetActor()->GetActorUpVector() * 400, 25, FColor::Yellow, 2);
			isDetected = true;
			character->SetCanLink(true);

			//Appel de l'icone d'interact  
			if (asContact || Cast<ASource>(resultTarget.GetActor()))
				INVOKE(onCanLinkLocker, true, FinalPosition());
			SCREEN_DEBUG_MESSAGE_WARNING(0,"Hit")
		}
		else
		{
			INVOKE(onCanLinkLocker, false, FinalPosition())
			isDetected = false;
			character->SetCanLink(false);
		}
	}
	else
	{
		INVOKE(onCanLinkLocker, false, FinalPosition())
		isDetected = false;
		character->SetCanLink(false);
	}

}
void AReflector::AllReflect()
{
	//Le réflecteur réflete le rayon à tous les réflecteurs qui lui sont lié
	bool _hit;
	
	for (auto link : allLinkReflector)
	{
		_hit = UKismetSystemLibrary::LineTraceSingleForObjects(WORLD, FinalPosition(), link->FinalPosition(), raySourceLayer, true, TArray<AActor*>(), EDrawDebugTrace::ForOneFrame, resultByEachLink, true);
		if (_hit)
		{
			//Check si il y a pas un joueur ou si le lien n'est pas couper sinon on coupe la dispersion à tous les réflecteurs qui lui sont liés
			if (Cast<APlayableCharacter>(resultByEachLink.GetActor()) || !asContact)
			{
				link->SetContact(false);
			}
			else
			{
				DRAW_LINE(FinalPosition(), link->FinalPosition(), color, 3)
				DRAW_SPHERE(link->GetActorLocation() + link->GetActorUpVector() * 400, 25, FColor::Yellow, 2);
				link->SetContact(true);
			}
			

		}
	}
}
#pragma endregion

#pragma region DRAW
void AReflector::DrawDebug()
{
	//Pour afficher le miroir qui va réflecter
	DRAW_SPHERE(FinalPosition(), 25, FColor::Red, 1);
}
#pragma endregion

#pragma region INIT
void AReflector::Bind()
{
	
	character = Cast<APlayableCharacter>(FPC->GetPawn());
	if (!character)
		return;
	AUI_HUD_Menu* hud =Cast<AUI_HUD_Menu>(FPC->GetHUD());
	if (!hud)
		return;
	//Créer une icone spécifique pour les réflecteurs 
	BIND(OnRegistre(), hud->Get(), &AUI_HUD_Menu::Create);
	//Sert à l'affichage d'une icone d'interaction quand tous les conditions sont requisent pour link
	BIND(OnCanLinkLocker(), character->Get(), &APlayableCharacter::ShowLink);

	//Fait le lien si les conditions sont bonnes
	BIND(OnLinkSource(), character->Get(), &APlayableCharacter::Dispersion);
	BIND(OnLinkLocker(), character->Get(), &APlayableCharacter::OpenLock);

	//Va appeler tous les réflecteurs mais des conditions sont requise pour faire des liens( si le joueur porte un réflecteur ou poèssede t'il à un lien avec une source)
	//Vérifie qu'on peut link
	character->BIND(OnInteract(), this, &AReflector::LinkReflector);
	character->BIND(OnInteract(), this, &AReflector::LinkSource);
	character->BIND(OnInteract(), this, &AReflector::LinkLocker);
}
#pragma endregion
