using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPlayer : MonoBehaviour
{
    public Slider EnergyBar;
    private int maxEnergy = 100;
    private int currentEnergy;
    private int minEnergy = 0;

    public static SliderPlayer instance;
    private WaitForSeconds regenTick = new WaitForSeconds(0.5f);
    private Coroutine regen;

    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = maxEnergy;
        EnergyBar.maxValue = maxEnergy;
        EnergyBar.value = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void usedEnergy(int amount)
   {
       if(currentEnergy - amount >= 0)
       {
            currentEnergy -= amount;
            EnergyBar.value = currentEnergy;

            if(regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(ReEnergy());
       }
       else
       {
           Debug.Log("Stamina++");
       }
   }

   private IEnumerator ReEnergy()
   {
        yield return new WaitForSeconds(2);

        while(currentEnergy < maxEnergy)
        {
            currentEnergy += maxEnergy / 100;
            EnergyBar.value = currentEnergy;
            yield return new WaitForSeconds(0.5f);
        }
        regen = null; 
   }
}
