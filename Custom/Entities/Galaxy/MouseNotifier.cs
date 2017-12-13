using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{
    /// <summary>
    /// Mouse input observer
    /// </summary>
    class MouseNotifier
    {
        private List<Marker> _subscribers;

        public MouseNotifier()
        {
            _subscribers = new List<Marker>();
        }

        /// <summary>
        /// Checks if the mouse has been clicked. If so, notify markers of mouse position
        /// </summary>
        public void Update()
        {
            if ( Input.MouseDown() )
            {
                NotifySubscribers( Input.MousePos() );
            }
        }

        /// <summary>
        /// Notifies subscribers of the position of the mouse
        /// </summary>
        private void NotifySubscribers( Vector2 MousePos )
        {
            foreach (Marker mkr in _subscribers)
            {
                mkr.RecieveNotice(MousePos);
            }
        }

        /// <summary>
        /// Subscribes a marker to recieve notice of mouse position
        /// </summary>
        public void AddSubscriber(Marker mkr)
        {
            _subscribers.Add(mkr);
        }
    }
}
