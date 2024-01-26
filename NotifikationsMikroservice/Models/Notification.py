from datetime import datetime

class Notification:
    def __init__(self, id, recipient_id, message, timestamp=None):
        self.id = id
        self.recipient_id = recipient_id
        self.message = message
        self.timestamp = timestamp or datetime.now()

    def send(self):
        # Implementer logik til at sende notifikationen
        pass

    def mark_as_read(self):
        # Implementer logik til at markere notifikationen som læst
        pass





