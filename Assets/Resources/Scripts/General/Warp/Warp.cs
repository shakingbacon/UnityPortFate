using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PolygonCollider2D))]
[ExecuteInEditMode] // make sure to reset polygon collider in editor
public class Warp : Interactable {

    public string goToMapName;

    void Start()
    {
        interactString = "Warp";
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Game/Warp Portal");
        GetComponent<Collider2D>().isTrigger = true;
        transform.transform.localScale = new Vector3(2, 2, 1);
        GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    public override void Interact()
    {
        StartCoroutine(WarpPlayer());
    }

    IEnumerator WarpPlayer()
    {
        PlayerInteractController.Instance.ShowInteractNotifier(false);
        ScreenFader.img.enabled = true;
        SoundDatabase.PlaySound(16);
        PlayerMovement.cantMove = true;
        yield return StartCoroutine(ScreenFader.FadeToBlack()); 
        CurrentMap.Instance.WarpPlayerToMap(goToMapName);
        yield return StartCoroutine(ScreenFader.FadeToClear());
        PlayerMovement.cantMove = false;
        ScreenFader.img.enabled = false;
        Destroy(CurrentMap.Instance.area.GetChild(0).gameObject);
        //PlayerInteractController.Instance.ShowInteractNotifier(false);
    }




}
