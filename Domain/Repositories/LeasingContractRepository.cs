using BAWLib;
using BAWLib.Configs;

namespace Domain.Repositories;

public class LeasingContractRepository(MotorContext context) : ARepository<LeasingContract>(context);