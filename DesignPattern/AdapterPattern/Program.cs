// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
/// 适配器模式用于解决功能已经存在，但是接口不兼容的情况，而不必再去重写已经存在的功能
/// 使用适配器模式，模拟手机充电接口不匹配的问题
/// 但是Adapter的存在会导致系统复杂度提高
using AdapterPattern.Adapters;
using AdapterPattern.Targets;

// Call
// 通过转接器实现Android充电器给IPhone手机充电
IIPhoneChargingPort iPhoneCharge = new ChargeAdapter();
iPhoneCharge.IPhoneCharge();
