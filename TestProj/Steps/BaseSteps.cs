using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProj.Context;

namespace TestProj.Steps
{
    public class BaseSteps
    {

          private EndPoints endPoints;
 
    public BaseSteps(APITestContext testContext) {
     endPoints = testContext.getEndPoints();
    }
 
    public EndPoints getEndPoints() {
        return endPoints;
    }
    }
}
