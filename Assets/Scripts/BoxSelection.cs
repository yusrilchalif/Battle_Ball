using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

namespace RTS
{
    public class BoxSelection : MonoBehaviour
    {
        [SerializeField] Projector projector;
        [SerializeField] Collider[] selections;
        [SerializeField] Box box;
        private Vector3 startPos, dragPos;
        private Camera cam;
        private Ray ray;

        private List<Unit> unitsSelected = new List<Unit>();

        // Start is called before the first frame update
        void Start()
        {
            cam = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 100f) && unitsSelected.Count > 0)
                {
                    foreach (var unit in unitsSelected)
                    {
                        unit.MoveUnit(hit.point);
                    }
                }
            }

            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                ray = cam.ScreenPointToRay(Input.mousePosition);

                Physics.Raycast(ray, out hit, 100f);

                if (Input.GetMouseButtonDown(0))
                {
                    projector.enabled = true;
                    //on drag start
                    startPos = hit.point;
                    box.baseMin = startPos;
                }

                //when dragging the mouse
                dragPos = hit.point;
                box.baseMax = dragPos;

                projector.aspectRatio = box.Size.x / box.Size.z;
                projector.orthographicSize = box.Size.z * 0.5f;
                projector.transform.position = box.Center;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                foreach (var unit in unitsSelected)
                {
                    unit.Selected(false);
                }

                unitsSelected.Clear();

                if (box.Size.magnitude < 0.1f)
                    return;

                projector.enabled = false;
                //when mouse released
                selections = Physics.OverlapBox(box.Center, box.Extents, Quaternion.identity);

                foreach (var obj in selections)
                {
                    Debug.Log(obj + " looped");
                    Unit unit = obj.GetComponent<Unit>();
                    unit.Selected(true);
                    unitsSelected.Add(unit);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawWireCube(box.Center, box.Size);
        }
    }

    [System.Serializable]
    public class Box
    {
        public Vector3 baseMin, baseMax;

        public Vector3 Center
        {
            get
            {
                Vector3 center = baseMin + (baseMax - baseMin) * 0.5f;
                center.y = (baseMax - baseMin).magnitude * 0.5f;
                return center;
            }
        }

        public Vector3 Size
        {
            get
            {
                return new Vector3(Mathf.Abs(baseMax.x - baseMin.x), (baseMax - baseMin).magnitude, Mathf.Abs(baseMax.z - baseMin.z));
            }
        }

        public Vector3 Extents
        {
            get
            {
                return Size * 0.5f;
            }
        }
    }
}
