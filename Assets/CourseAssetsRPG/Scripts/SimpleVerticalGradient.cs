using UnityEngine;
using UnityEngine.UI;

namespace JackSParrot.UI.DOTween
{
    public class SimpleVerticalGradient : BaseMeshEffect
    {
        [SerializeField]
        private Color _top;
        [SerializeField]
        private Color _bottom;

        public override void ModifyMesh(VertexHelper vh)
        {
            if (!IsActive())
                return;

            //bottom-left
            var vert0 = new UIVertex();
            vh.PopulateUIVertex(ref vert0, 0);
            vert0.color = _bottom;
            vh.SetUIVertex(vert0, 0);

            //bottom-right
            var vert1 = new UIVertex();
            vh.PopulateUIVertex(ref vert1, 3);
            vert1.color = _bottom;
            vh.SetUIVertex(vert1, 3);

            //top-right
            var vert2 = new UIVertex();
            vh.PopulateUIVertex(ref vert2, 1);
            vert2.color = _top;
            vh.SetUIVertex(vert2, 1);

            //top-left
            var vert3 = new UIVertex();
            vh.PopulateUIVertex(ref vert3, 2);
            vert3.color = _top;
            vh.SetUIVertex(vert3, 2);
        }
    }
}