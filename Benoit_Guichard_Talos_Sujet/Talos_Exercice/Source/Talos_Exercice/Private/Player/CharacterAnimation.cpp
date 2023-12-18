#include "Player/CharacterAnimation.h"
#include "Player/PlayableCharacter.h"
#include "../Utils.h"
#include "../DebugUtils.h"


void UCharacterAnimation::NativeBeginPlay()
{
	Super::NativeBeginPlay();
	Bind();
}

void UCharacterAnimation::MoveForwardAnimation(const float _axis)
{

	speedForward = _axis;
}

void UCharacterAnimation::Bind()
{
	APlayableCharacter* _player = Cast<APlayableCharacter>(TryGetPawnOwner());
	if (!_player)
		return;
	
	_player->OnMoveForward().AddDynamic(this, &UCharacterAnimation::MoveForwardAnimation);

}
