// See https://aka.ms/new-console-template for more information
using StatePattern.Contexts;
using StatePattern.StateEnums;
using StatePattern.States;
using StatePattern.States.IStates;

/// 状态模式：让对象在内部状态发生改变时改变其行为
/// 
// Call
WaterStateContext context = new();
context.CurrentWaterSate = new WaterGas();
context.Action();
context.SetState(new WaterSolid());
context.Action();
context.SetState2(WaterStateEnum.Liquid);
context.Action();