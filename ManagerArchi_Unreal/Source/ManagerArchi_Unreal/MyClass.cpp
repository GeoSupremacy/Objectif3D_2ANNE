
#include "MyClass.h"

#include "SingletonPattern.h"

// Sets default values
AMyClass::AMyClass()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
	
}


void AMyClass::BeginPlay()
{
	Super::BeginPlay();
	
}
void AMyClass::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

