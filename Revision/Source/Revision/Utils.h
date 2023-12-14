#pragma once

#define INVOKE(eventName,...) eventName.Broadcast(__VA_ARGS__);