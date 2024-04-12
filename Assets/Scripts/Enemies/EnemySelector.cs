using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelector : MonoBehaviour
{
    [SerializeField] GameObject selectorSprite;

    EnemyBrain brain;

    private void Awake()
    {
        brain = GetComponent<EnemyBrain>();
    }

    private void Start()
    {
        SelectionManager.OnEnemySelected += ActivateSelector;
        SelectionManager.OnNoSelection += DeactivateSelector;
    }

    void ActivateSelector(EnemyBrain _brain)
    {
        selectorSprite.SetActive(brain == _brain);

    }

    void DeactivateSelector()
    {
        selectorSprite.SetActive(false);
    }
}
