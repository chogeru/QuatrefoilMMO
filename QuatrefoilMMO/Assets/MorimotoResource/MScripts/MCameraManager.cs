using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MCameraManager : MonoBehaviour
{
    [Serializable]
    public class Parameter
    {
        public Transform trackTraget;
        public Vector3 position;
        public Vector3 angles = new Vector3(10f, 0f, 0f);
        public float distance = 7f;
        public float fieldOfView = 45f;
        public Vector3 offsetPosition = new Vector3(0f, 1f, 0f);
        public Vector3 offsetAngles;
    }

    [SerializeField]
    private Transform m_parent;

    [SerializeField]
    private Transform m_child;

    [SerializeField]
    private Camera m_camera;

    [SerializeField]
    private Parameter m_parameter;

    [SerializeField]
    private float m_rotateAngleMinX = -50f;

    [SerializeField]
    private float m_rotateAngleMaxX = 75f;

    [SerializeField]
    private float m_zoomMin = 2f;

    [SerializeField]
    private float m_zoomMax = 11f;

    [SerializeField]
    private float m_zoomSpeed = 0.1f;

    [SerializeField]
    private float m_lastCameraDist = -1f;

    public void Update()
    {
        Vector3 diffAngles = new Vector3
        (
            x: -Input.GetAxis("Mouse Y"),
            y: Input.GetAxis("Mouse X")
        ) * 10f;

        //拡大用マウススクロール
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        m_parameter.angles += diffAngles;
        m_parameter.angles.x = Mathf.Clamp(m_parameter.angles.x, m_rotateAngleMinX, m_rotateAngleMaxX);
    }

    private void LateUpdate()
    {
        if (m_parent == null || m_child == null || m_camera == null)
        {
            return;
        }

        if (m_parameter.trackTraget != null)
        {
            m_parameter.position = Vector3.Lerp
            (
                a: m_parameter.position,
                b: m_parameter.trackTraget.position,
                t: Time.deltaTime * 4f
            );
        }

        m_parent.position = m_parameter.position;
        m_parent.eulerAngles = m_parameter.angles;

        var childPos = m_child.localPosition;
        childPos.z = -m_parameter.distance;
        m_child.localPosition = childPos;

        m_camera.fieldOfView = m_parameter.fieldOfView;
        m_camera.transform.localPosition = m_parameter.offsetPosition;
        m_camera.transform.localEulerAngles = m_parameter.offsetAngles;

        Vector3 lookAtPos = m_parent.position + m_parameter.offsetPosition;
        Vector3 cameraPos = m_camera.transform.position;
        Vector3 vec = cameraPos - lookAtPos;
        float cameraDist = vec.magnitude;
        Ray ray = new Ray(lookAtPos, vec);
        int layerMask = LayerMask.GetMask("Default");//コリジョンの床、壁にレイヤーを付ける
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, vec.magnitude, layerMask))
        {
            Vector3 hitVec = hit.point - lookAtPos;
            cameraDist = hitVec.magnitude * 0.8f;
        }

        if (m_lastCameraDist < cameraDist)
        {
            cameraDist = Mathf.Lerp(m_lastCameraDist, cameraDist, 6f * Time.deltaTime);
        }

        m_camera.transform.position = lookAtPos + vec.normalized * cameraDist;
        m_lastCameraDist = cameraDist;
    }
}
