#pragma once
#include "DebugUtils.h"
#define INVOKE(eventName,...) eventName.Broadcast(__VA_ARGS__);